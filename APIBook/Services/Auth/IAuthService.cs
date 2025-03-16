using APIBook.Dtos;
using CommonHelper.Models;

namespace APIBook.Services
{
	public interface IAuthService
	{
		Task<ServiceTranferModel<UserLoginResponseDto>> Login(string userName, string passWord);
		//Task<ServiceTranferModel<UserLoginResponseDto>> Login(string userName, string passWord, string appKey);
		Task<ServiceTranferModel<UserLoginResponseDto>> RefreshToken(RefeshTokenDto request);
		Task<CurrentUserDto> CurrentUser();
		Task<bool> Logout(Guid userId);
	}
}
