using Api.Services;
using APIBook.Dtos;
using APIBook.Services;
using CommonHelper.Enum;
using CommonHelper.Models;

using Cryptography;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.V1
{
	[Route("v1/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly ILogger<AuthController> _logger;
		private readonly IAuthService _authService;
		public AuthController(ILogger<AuthController> logger, IAuthService authService)
		{
			_logger = logger;
			_authService = authService;
		}

		[HttpPost]
		[Route("login")]
		[AllowAnonymous]
		public async Task<IActionResult> LoginAsync([FromBody] LoginRequestDto request)
		{
			try
			{
				var response = await _authService.Login(request.UserName, request.Password);
				if (response == null)
				{
					return Ok(ResponseModel.Error("Thông tin đăng nhập không đúng !"));
				}
				else if (response.Status == (int)UserLoginSatus.Ok)
				{
					return Ok(ResponseModel.Success(response.Data, "Đăng nhập thành công !"));
				}
				else
				{
					return Ok(ResponseModel.Error(response.Message));
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError, "Không thể đăng nhập, vui lòng xem lại !");
			}
		}

		//[HttpPost]
		//[Route("private-auth")]
		//[AllowAnonymous]
		//public async Task<IActionResult> PrivateAuthAsync([FromBody] LoginRequestDto request)
		//{
		//	try
		//	{
		//		var response = await _authService.Login(request.UserName, request.Password, request.Captcha);
		//		if (response == null)
		//		{
		//			return Ok(ResponseModel.Error("Thông tin đăng nhập không đúng !"));
		//		}
		//		else if (response.Status == (int)UserLoginSatus.Ok)
		//		{
		//			return Ok(ResponseModel.Success(response.Data, "Đăng nhập thành công !"));
		//		}
		//		else
		//		{
		//			return Ok(ResponseModel.Error(response.Message));
		//		}
		//	}
		//	catch (Exception ex)
		//	{
		//		_logger.LogError(ex.Message);
		//		return StatusCode(StatusCodes.Status500InternalServerError, "Không thể đăng nhập, vui lòng xem lại !");
		//	}
		//}

		[HttpPost]
		[Route("refresh-token")]
		public async Task<IActionResult> RefreshTokenAsync([FromBody] RefeshTokenDto request)
		{
			try
			{
				var response = await _authService.RefreshToken(request);
				if (response.Status == (int)RefreshTokenEnum.Ok)
				{
					return Ok(ResponseModel.Success(response.Data, "Refresh token thành công !"));
				}
				else if (response.Status == (int)RefreshTokenEnum.RefreshTokenExpire)
				{
					return Ok(ResponseModel.Error((int)RefreshTokenEnum.RefreshTokenExpire, "Refresh token đã hết hạn !"));
				}
				else
				{
					return Ok(ResponseModel.Error(response.Message));
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError, "Không thể thực hiện refresh token !");
			}
		}

		[HttpGet]
		[Route("current-user")]
		[Authorize]
		public async Task<IActionResult> CurrentUserAsync()
		{
			try
			{
				return Ok(ResponseModel.Success(await _authService.CurrentUser()));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError, "Không thể thực hiện");
			}
		}

		[HttpPost]
		[Route("logout")]
		[Authorize]
		public async Task<IActionResult> LogoutAsync()
		{
			try
			{
				Guid userId = Guid.Parse(User.Claims.FirstOrDefault(n => n.Type == "Id").Value);
				var response = await _authService.Logout(userId);
				return Ok(ResponseModel.Success(response));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError, "Không thể đăng xuất !");
			}
		}

		//[HttpGet]
		//[Route("captcha")]
		//[AllowAnonymous]
		//public IActionResult GetCaptchaAsync()
		//{
		//	try
		//	{
		//		var captcha = CaptchaHeper.GenerateCaptchaCode(5);
		//		var captchaCode = CryptionHander.EncryptString(captcha.ToUpper());
		//		var captchaImage = "data:image/png;base64, " + Convert.ToBase64String(CaptchaHeper.GenerateCaptchaImage(captcha.ToUpper(), 150, 32));

		//		return Ok(ResponseModel.Success(new CaptchaDto { Captcha = captchaImage, CaptchaCode = captchaCode }));
		//	}
		//	catch (Exception ex)
		//	{
		//		_logger.LogError(ex.Message);
		//		return StatusCode(StatusCodes.Status500InternalServerError, "Không thể lấy captcha, vui lòng thử lại !");
		//	}
		//}
	}
}
