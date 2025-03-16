using APIBook.Dtos;
using APIBook.Options;
using ApiDomain.Base;
using ApiDomain.Contract;
using ApiDomain.Entity;
using AutoMapper;
using Cache;
using CommonHelper.Constant;
using CommonHelper.Enum;
using CommonHelper.Models;
using Cryptography;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace APIBook.Services
{
	public class AuthService : IAuthService
	{
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly IUserRepository _userRepository;
		private readonly IRepository<ActionLog> _actionLogService;
		private readonly IPermissionRepository _userPermissionRepository;
		private readonly IRoleRepository _roleRepository;
		private readonly IMemoryCache _memoryCache;
		private readonly IMapper _mapper;
		private readonly JwtOptions _jwtOptions;
		private readonly IConfiguration _configuration;
		public AuthService(IHttpContextAccessor httpContextAccessor, IUserRepository userRepository, IPermissionRepository userPermissionRepository, IRoleRepository roleRepository, IMemoryCache memoryCache, IMapper mapper, IOptions<JwtOptions> jwtOptions, IConfiguration configuration)
		{
			_httpContextAccessor = httpContextAccessor;
			_userRepository = userRepository;
			_userPermissionRepository = userPermissionRepository;
			_roleRepository = roleRepository;
			_memoryCache = memoryCache;
			_mapper = mapper;
			_jwtOptions = jwtOptions.Value;
			_configuration = configuration;
		}

		public async Task<ServiceTranferModel<UserLoginResponseDto>> Login(string userName, string passWord)
		{
			var user = await _userRepository.FindByUserNameAsync(userName);
			if (user == null) return null;
			if (user.Password != CryptionHander.EncryptString(passWord)) return new ServiceTranferModel<UserLoginResponseDto>(null, (int)UserLoginSatus.WrongPass, "Sai mật khẩu, vui lòng thử lại !");
			if (user.Status == (int)UserStatusEnum.Locked) return new ServiceTranferModel<UserLoginResponseDto>(null, (int)UserLoginSatus.Locked, "Tài khoản của bạn đang bị khóa, vui lòng thử lại !");

			var role = await _roleRepository.FindByIdAsync(user.RoleID);
			if (role == null || role.Code == StringConstant.ClientCode)
			{
				return new ServiceTranferModel<UserLoginResponseDto>(null, (int)UserLoginSatus.Locked, "Tài khoản của bạn không có quyền truy cập, vui lòng thử lại !");
			}
			var accessToken = GenerateAccessToken(user);
			var refreshToken = GenerateRefreshToken();
			var loginResponse = new UserLoginResponseDto
			{
				UserName = userName,
				Id = user.Id,
				Avatar = user.Avatar,
				AccessToken = accessToken.Token,
				RefreshToken = refreshToken.Token,
			};
			await _userRepository.DeleteUserTokenAsync(user.Id);
			await _userRepository.InsertUserTokenAsync(new UserToken
			{
				Id = Guid.NewGuid(),
				AccessToken = accessToken.Token,
				UserId = user.Id,
				AccessTokenExpire = accessToken.Expire.Value,
				CreatedBy = user.CreateBy,
				CreatedDate=user.CreateDate,
				RefreshToken = refreshToken.Token,
				RefreshTokenExpire = refreshToken.Expire.Value,
			});
			return new ServiceTranferModel<UserLoginResponseDto>(loginResponse, (int)UserLoginSatus.Ok, "Đăng nhập thành công !");
		}
		public async Task<ServiceTranferModel<UserLoginResponseDto>> RefreshToken(RefeshTokenDto request)
		{
			if (string.IsNullOrEmpty(request.AccessToken))
				return new ServiceTranferModel<UserLoginResponseDto>(null, (int)RefreshTokenEnum.TokenEmpty, "Access token không được để trống");

			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(_jwtOptions.Secret);
			try
			{
				tokenHandler.ValidateToken(request.AccessToken, new TokenValidationParameters
				{
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidAudience = _jwtOptions.Audience,
					ValidIssuer = _jwtOptions.Issuer,
					IssuerSigningKey = new SymmetricSecurityKey(key),
					ValidateLifetime = false,
				}, out SecurityToken validatedToken);

				var jwtToken = (JwtSecurityToken)validatedToken;
				var userId = Guid.Parse(jwtToken.Claims.First(x => x.Type == "Id").Value);

				var userToken = await _userRepository.FindUserTokenByUserId(userId);
				if (userToken == null) return new ServiceTranferModel<UserLoginResponseDto>(null, (int)RefreshTokenEnum.NotFound, "Không thể Refesh token khi chưa đăng nhập !");

				var user = await _userRepository.FindByIdAsync(userId);
				if (user == null) return new ServiceTranferModel<UserLoginResponseDto>(null, (int)RefreshTokenEnum.NotFound, "Không tìm thấy tài khoản này !");

				var accessToken = GenerateAccessToken(user);

				// nếu refresh token còn hạn => cập nhật lại accesstoken
				if (userToken.RefreshTokenExpire > DateTime.Now)
				{
					userToken.AccessToken = accessToken.Token;
					userToken.AccessTokenExpire = accessToken.Expire.Value;

					await _userRepository.UpdateUserTokenAsync(userToken);
					var refreshResponse = new UserLoginResponseDto
					{
						AccessToken = accessToken.Token,
					};
					return new ServiceTranferModel<UserLoginResponseDto>(refreshResponse,
						(int)RefreshTokenEnum.Ok,
						"Refresh Token thành công !"
					);
				}
				return new ServiceTranferModel<UserLoginResponseDto>(null, (int)RefreshTokenEnum.RefreshTokenExpire, "Refresh Token đã hết hạn, vui lòng đăng nhập lại ");
			}
			catch
			{
				return new ServiceTranferModel<UserLoginResponseDto>(null, (int)RefreshTokenEnum.NotValid, "Token không hợp lệ hoặc đã hết hạn !");
			}
		}
		public async Task<CurrentUserDto> CurrentUser()
		{
			Guid userId = Guid.Parse(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(n => n.Type == "Id").Value);
			string userCachedKey = CacheKeyBuilder.BuildCurrentUserCacheKey(userId);
			var cachedUser = _memoryCache.Get<CurrentUserDto>(userCachedKey);
			if (cachedUser == null)
			{
				var user = await _userRepository.FindByIdAndRoleAsync(userId);
				if (user == null) return null;
				var curentUser = new CurrentUserDto
				{
					Id = userId,
					FullName=user.FullName,
					Address = user.Address,
					Avatar = user.Avatar,
					CreateBy = user.CreateBy,
					CreateDate = user.CreateDate,
					DateOfBirth = user.DateOfBirth,
					Email = user.Email,
					IsAdmin = user.Role?.IsAdmin,
					ModifiedBy = user.ModifiedBy,
					Status = user.Status,
					ModifiedDate = user.ModifiedDate,
					UserName = user.UserName,
					RoleID= user.RoleID,
					UserPermissions = (await _userPermissionRepository.GetUserPermission(userId)).Select(n => n.Code).ToList(),
				};
				_memoryCache.Set<CurrentUserDto>(userCachedKey, curentUser, new MemoryCacheEntryOptions { AbsoluteExpiration = DateTime.Now.AddMinutes(30) });
				return curentUser;
			}
			else return cachedUser;

		}
		public async Task<bool> Logout(Guid userId)
		{
			var user = await _userRepository.FindByIdAsync(userId);
			await _userRepository.DeleteUserTokenAsync(userId);
			return true;
		}
		private GenerateTokenDto GenerateAccessToken(User userInfo)
		{
			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Secret));
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
			var expire = DateTime.Now.AddMinutes(_jwtOptions.AccessTokenExpireMinutes);
			IEnumerable<Claim> claims = new List<Claim>
			{
				new Claim(ClaimTypes.NameIdentifier, userInfo.Id.ToString()),
				new Claim(ClaimTypes.Name, userInfo.FullName ?? ""),
				new Claim("Id", userInfo.Id.ToString()),
			};
			var token = new JwtSecurityToken(_jwtOptions.Issuer,
			  _jwtOptions.Audience,
			  claims,
			  expires: expire,
			  signingCredentials: credentials);

			return new GenerateTokenDto
			{
				Expire = expire,
				Token = new JwtSecurityTokenHandler().WriteToken(token)
			};
		}
		//private GenerateTokenDto GeneratePrivateAccessToken(User userInfo)
		//{
		//	var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Secret));
		//	var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
		//	var expire = DateTime.Now.AddDays(_jwtOptions.AccessTokenExpireMinutes);
		//	IEnumerable<Claim> claims = new List<Claim>
		//	{
		//		new Claim(ClaimTypes.NameIdentifier, userInfo.Id.ToString()),
		//		new Claim(ClaimTypes.Name, userInfo.FullName ?? ""),
		//		new Claim("Id", userInfo.Id.ToString()),
		//	};
		//	var token = new JwtSecurityToken(_jwtOptions.Issuer,
		//	  _jwtOptions.Issuer,
		//	  claims,
		//	  expires: expire,
		//	  signingCredentials: credentials);

		//	return new GenerateTokenDto
		//	{
		//		Expire = expire,
		//		Token = new JwtSecurityTokenHandler().WriteToken(token)
		//	};
		//}
		private GenerateTokenDto GenerateRefreshToken()
		{
			var expire = DateTime.Now.AddDays(_jwtOptions.ExpireTokenExpireDays);
			var randomNumber = new byte[32];
			using (var rng = RandomNumberGenerator.Create())
			{
				rng.GetBytes(randomNumber);
				return new GenerateTokenDto
				{
					Token = Convert.ToBase64String(randomNumber),
					Expire = expire,
				};
			}
		}
	}
}
