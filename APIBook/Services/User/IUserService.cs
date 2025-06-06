using APIBook.Dtos;
using CommonHelper.Models;

namespace APIBook.Services
{
	public interface IUserService
	{
		Task<PaginationModel<UserCreateDto>> GetListAsync(FilterRequest request);
		Task<UserViewDto> GetProfileAsync(Guid id);
		Task<UserCreateDto> GetByIdAsync(Guid id);
		Task<List<UserCreateDto>> GetByPositionAsync(string code);
		Task<UserCreateDto> CreateAsync(UserCreateDto request);
		Task<UserCreateDto> UpdateAsync(UserCreateDto request);
		Task<UserCreateDto> DeleteAsync(Guid id);
		Task<bool> UpdatePasswordAsync(Guid userId, string userName, string newPass, string oldPass);
		Task<UserCreateDto> ResetPasswordAsync(Guid id);
	}
}
