using APIBook.Dtos;
using CommonHelper.Models;

namespace APIBook.Services
{
	public interface IUserService
	{
		Task<PaginationModel<UserCreateDto>> GetListAsync(FilterRequest request);
		Task<UserViewDto> GetProfileAsync(Guid userId);
		Task<UserCreateDto> GetByIdAsync(Guid userId);
		Task<List<UserCreateDto>> GetByPositionAsync(string code);
		Task<UserCreateDto> CreateAsync(UserCreateDto request);
		Task<UserCreateDto> UpdateAsync(UserCreateDto request);
		Task<UserCreateDto> DeleteAsync(Guid userId);
		Task<bool> UpdatePasswordAsync(Guid userId, string userName, string newPass, string oldPass);
		Task<UserCreateDto> ResetPasswordAsync(Guid userId);
	}
}
