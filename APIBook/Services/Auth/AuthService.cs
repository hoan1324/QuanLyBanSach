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
		private readonly IPermissionRepository _permissionRepository;
		private readonly IRoleRepository _roleRepository;
		private readonly IMemoryCache _memoryCache;
		private readonly IMapper _mapper;
		private readonly JwtOptions _jwtOptions;
		private readonly IConfiguration _configuration;
		private readonly IUserTokenRepository _userTokenRepository;
		private readonly ICacheService _cacheService;
        public AuthService(IHttpContextAccessor httpContextAccessor, IUserRepository userRepository, IPermissionRepository permissionRepository, IRoleRepository roleRepository, IMemoryCache memoryCache, IMapper mapper, IOptions<JwtOptions> jwtOptions, IConfiguration configuration,IUserTokenRepository userTokenRepository,ICacheService cacheService)
		{
			_httpContextAccessor = httpContextAccessor;
			_userRepository = userRepository;
			_permissionRepository = permissionRepository;
			_roleRepository = roleRepository;
			_memoryCache = memoryCache;
			_mapper = mapper;
			_jwtOptions = jwtOptions.Value;
			_configuration = configuration;
            _userTokenRepository = userTokenRepository;
			_cacheService = cacheService;
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
			await _userTokenRepository.DeleteUserTokenAsync(user.Id);
			await _userTokenRepository.InsertUserTokenAsync(new UserToken
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
			_httpContextAccessor.HttpContext.Response.Cookies.Append("RefreshToken", CryptionHander.EncryptString(refreshToken.Token), new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.None,
                Expires = DateTimeOffset.UtcNow.AddDays(_jwtOptions.ExpireTokenExpireDays)
            });
            return new ServiceTranferModel<UserLoginResponseDto>(loginResponse, (int)UserLoginSatus.Ok, "Đăng nhập thành công !");
		}
		public async Task<ServiceTranferModel<UserLoginResponseDto>> RefreshToken(RefeshTokenDto request)
		{
            if (string.IsNullOrWhiteSpace(request.RefreshTokenValue) || string.IsNullOrWhiteSpace(request.AccessToken))
                return new ServiceTranferModel<UserLoginResponseDto>(null, (int)RefreshTokenEnum.TokenEmpty, "Access token và Refresh Token không được để trống");

			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(_jwtOptions.Secret);
			try
			{
                var tokenInVerfication=tokenHandler.ValidateToken(request.AccessToken, new TokenValidationParameters
				{
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidAudience = _jwtOptions.Audience,
					ValidIssuer = _jwtOptions.Issuer,
					IssuerSigningKey = new SymmetricSecurityKey(key),
					ValidateLifetime = false,
				}, out SecurityToken validatedToken);



				//kiểm tra loại thuật toán sử dụng
				if (validatedToken is JwtSecurityToken jwtToken)
				{
					var result = jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase);
					if (!result)
					{
						return new ServiceTranferModel<UserLoginResponseDto>(null, (int)AccessTokenEnum.NotValid, "Access token không hợp lệ");
					}

				}


                if (validatedToken.ValidTo > DateTime.Now)
                {
                    return new ServiceTranferModel<UserLoginResponseDto>(null, (int)AccessTokenEnum.NotExpired, "Access token còn hạn");
                }

                var userId = tokenInVerfication.Claims.FirstOrDefault(c => c.Type == "Id")?.Value;
                if (userId == null)
                {
                    return new ServiceTranferModel<UserLoginResponseDto>(null, (int)AccessTokenEnum.NotValid, "Access token không hợp lệ");
                }

                var userToken = await _userTokenRepository.FindUserTokenByUserId(Guid.Parse(userId));
                if (userToken == null) return new ServiceTranferModel<UserLoginResponseDto>(null, (int)RefreshTokenEnum.NotFound, "Bạn chưa đăng nhập");;
                if (userToken.RefreshToken != request.RefreshTokenValue || userToken.AccessToken != request.AccessToken)
                {
                    return new ServiceTranferModel<UserLoginResponseDto>(null, (int)RefreshTokenEnum.NotValid, "Access token hoặc Refresh Token không hợp lệ");
                }


                // nếu refresh token còn hạn => cập nhật lại accesstoken
                if (userToken.RefreshTokenExpire > DateTime.Now)
                {
                    var user = await _userRepository.FindByIdAsync(userToken.UserId);
                    var accessToken = GenerateAccessToken(user);
                    var refreshToken = GenerateRefreshToken();
                    userToken.AccessToken = accessToken.Token;
                    userToken.AccessTokenExpire = accessToken.Expire.Value;
                    userToken.RefreshToken = refreshToken.Token;

                    await _userTokenRepository.UpdateUserTokenAsync(userToken);
                    var refreshResponse = new UserLoginResponseDto
                    {
                        RefreshToken = refreshToken.Token,
                        AccessToken = accessToken.Token,
                    };


                    return new ServiceTranferModel<UserLoginResponseDto>(null, (int)RefreshTokenEnum.Ok, "Refresh Token thành công");
                }
                return new ServiceTranferModel<UserLoginResponseDto>(null, (int)RefreshTokenEnum.RefreshTokenExpire, "Refresh Token thất bại");
            }
            catch (Exception ex)
            {
                return new ServiceTranferModel<UserLoginResponseDto>(null, (int)RefreshTokenEnum.NotValid, "Token không hợp lệ hoặc đã hết hạn");
            }
        }
		public async Task<CurrentUserDto> CurrentUser()
		{
			Guid userId = Guid.Parse(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(n => n.Type == "Id").Value);
			return await _cacheService.GetUserFromCache(userId);

		}
		public async Task<bool> Logout(Guid userId)
		{
			await _userTokenRepository.DeleteUserTokenAsync(userId);
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

        public async Task<bool> IsTokenExists(string accessToken)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
                return false;

            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.ReadJwtToken(accessToken);

                // Lấy userId từ claim "Id" (hoặc "id", tùy bạn lưu claim)
                var userId = token.Claims.FirstOrDefault(c => c.Type == "Id")?.Value;
                if (string.IsNullOrEmpty(userId))
                    return false;

                // Tìm token trong DB theo userId
                var userToken = await _userTokenRepository.FindUserTokenByUserId(Guid.Parse(userId));
                if (userToken == null)
                    return false;

                // So sánh token trong DB với token truyền vào
                return userToken.AccessToken == accessToken;
            }
            catch
            {
                // Nếu decode hoặc parse token lỗi => token không hợp lệ
                return false;
            }
        }
    }
}
