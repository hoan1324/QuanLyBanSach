using APIBook.Dtos;
using ApiDomain.Contract;
using Cache;
using Microsoft.Extensions.Caching.Memory;

namespace APIBook.Services
{
	public class CacheService : ICacheService
	{
		private readonly IMemoryCache _memoryCache;
		private readonly IUserRepository _userRepository;
		private readonly IPermissionRepository _permissionRepository;
		public CacheService(IMemoryCache memoryCache, IUserRepository userRepository, IPermissionRepository permissionRepository)
		{
			_memoryCache = memoryCache;
			_userRepository = userRepository;
			_permissionRepository = permissionRepository;
		}
		public async Task<CurrentUserDto> GetUserFromCache(Guid userId)
		{
			string userCachedKey = CacheKeyBuilder.BuildCurrentUserCacheKey(userId);
			await LoadUserToCache(userId);
			return _memoryCache.Get<CurrentUserDto>(userCachedKey);
		}

		public async Task LoadUserToCache(Guid userId, bool isReplace = false)
		{
			string userCachedKey = CacheKeyBuilder.BuildCurrentUserCacheKey(userId);
			if (isReplace) RemoveUserFromCache(userId);
			var cachedUser = _memoryCache.Get<CurrentUserDto>(userCachedKey);
			if (cachedUser == null)
			{
				var user = await _userRepository.FindByIdAndRoleAsync(userId);
                var userPermission = await _permissionRepository.GetUserPermission(userId);
                var rolePermission = await _permissionRepository.GetRolePermission(user.RoleID);
                if (user != null)
				{
					var curentUser = new CurrentUserDto
					{
						Id = userId,
						PhoneNumber=user.PhoneNumber,
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
						RoleID = user.RoleID,
                        UserPermissions = userPermission.Concat(rolePermission).Select(n => n.Code).Distinct().ToList(),
                        Gender = user.Gender,
					};
					_memoryCache.Set<CurrentUserDto>(userCachedKey, curentUser, new MemoryCacheEntryOptions { AbsoluteExpiration = DateTime.Now.AddMinutes(30) });
				}
			}
		}

		public void RemoveUserFromCache(Guid userId)
		{
			string userCachedKey = CacheKeyBuilder.BuildCurrentUserCacheKey(userId);
			var cachedUser = _memoryCache.Get<CurrentUserDto>(userCachedKey);
			if (cachedUser != null)
			{
				_memoryCache.Remove(userCachedKey);
			}
		}
	}

}
