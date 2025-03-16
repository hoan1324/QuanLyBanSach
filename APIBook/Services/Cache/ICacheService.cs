using APIBook.Dtos;

namespace APIBook.Services
{
	public interface ICacheService
	{
		Task<CurrentUserDto> GetUserFromCache(Guid userId);
		Task LoadUserToCache(Guid userId, bool isReplace = false);
		void RemoveUserFromCache(Guid userId);
	}
}
