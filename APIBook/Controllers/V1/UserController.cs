
using Api.Services;
using APIBook.Attributes;
using APIBook.Dtos;
using APIBook.Services;
using CommonHelper.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.V1
{
	[Route("v1/[controller]")]
	[ApiController]
	[Authorize]
	[UserAuthorize]
	public class UserController : ControllerBase
	{
		private readonly IWebHostEnvironment _webHostEnvironment;
		private readonly ILogger<UserController> _logger;
		private readonly IUserService _userService;
		//private readonly IActionLogService _actionLogService;
		private readonly IAuthService _authService;

		public UserController(ILogger<UserController> logger, IUserService userService, IWebHostEnvironment webHostEnvironment, IAuthService authService)
		{
			_logger = logger;
			_userService = userService;
			_webHostEnvironment = webHostEnvironment;
			//_actionLogService = actionLogService;
			_authService = authService;
		}

	
		
		[HttpGet]
		[Route("")]
		[PermissionDescription("Xem danh sách tài khoản")]
		public async Task<IActionResult> GetListAsync([FromQuery] FilterRequest request)
		{
			try
			{
				var response = await _userService.GetListAsync(request);
				return Ok(ResponseModel.Success(response));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError, "Không thể lấy dữ liệu người dùng !");
			}
		}

		[HttpGet]
		[Route("{id}")]
		[PermissionDescription("Xem chi tiết tài khoản")]
		public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
		{
			try
			{
				var response = await _userService.GetByIdAsync(id);
				if (response == null) return Ok(ResponseModel.Error(null, "Người dùng không tồn tại !"));
				else
				{
					response.Password = "";
					return Ok(ResponseModel.Success(response));
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError, "Không thể lấy dữ liệu người dùng !");
			}
		}

		[HttpPost]
		[Route("")]
		[PermissionDescription("Tạo tài khoản")]
		public async Task<IActionResult> CreateAsync([FromBody] UserCreateDto request)
		{
			try
			{
				var response = await _userService.CreateAsync(request);
				if (response != null)
				{
					//var currentUser = await _authService.CurrentUser();
					//await _actionLogService.CreateAsync(new ActionLogDto
					//{
					//	Title = "Tạo mới người dùng",
					//	Description = $"{currentUser.UserName} đã tạo mới người dùng : {response.UserName}"

					//});

					return Ok(ResponseModel.Success(response, "Tạo mới người dùng thành công !"));
				}
				else return Ok(ResponseModel.Error(null, "Tạo mới người dùng thất bại do trùng tên tài khoản !"));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError, "Không thể tạo tài khoản, vui lòng xem lại !");
			}
		}

		[HttpPut]
		[Route("{id}")]
		[PermissionDescription("Cập nhật tài khoản")]
		public async Task<IActionResult> UpdateAsync([FromBody] UserCreateDto request)
		{
			try
			{
				var response = await _userService.UpdateAsync(request);
				if (response != null)
				{
					//var currentUser = await _authService.CurrentUser();
					//await _actionLogService.CreateAsync(new ActionLogDto
					//{
					//	Title = "Cập nhật người dùng",
					//	Description = $"{currentUser.UserName} đã cập nhật người dùng : {response.UserName}"

					//});
					return Ok(ResponseModel.Success(response, "Cập nhật người dùng thành công !"));
				}
				else return Ok(ResponseModel.Error(null, "Cập nhật người dùng thất bại !"));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError, "Không thể cập nhật tài khoản, vui lòng xem lại !");
			}
		}
		[HttpPost]
		[Route("change-password")]
		[PermissionDescription("Đổi mật khẩu")]
		public async Task<IActionResult> UpdatePasswordAsync([FromBody] UserChangePasswordDto request)
		{
			try
			{
				var response = await _userService.UpdatePasswordAsync(request.Id, request.UserName, request.NewPassword, request.OldPassword);
				if (response)
				{
					//var currentUser = await _authService.CurrentUser();
					//await _actionLogService.CreateAsync(new ActionLogDto
					//{
					//	Title = "Cập nhật mật khẩu",
					//	Description = $"{currentUser.UserName} đã cập nhật mật khẩu của tài khoản : {request.UserName}"

					//});
					return Ok(ResponseModel.Success(response, "Cập nhật người mật khẩu công !"));
				}
				else return Ok(ResponseModel.Error(null, "Cập nhật mật khẩu thất bại !"));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError, "Không thể cập nhật mật khẩu, vui lòng xem lại !");
			}
		}
		[HttpPost]
		[Route("reset-password")]
		[PermissionDescription("Reset mật khẩu")]
		public async Task<IActionResult> ResetPasswordAsync([FromBody] ResetPassDto request)
		{
			try
			{
				var response = await _userService.ResetPasswordAsync(request.Id);
				if (response != null)
				{
					//var currentUser = await _authService.CurrentUser();
					//await _actionLogService.CreateAsync(new ActionLogDto
					//{
					//	Title = "Reset mật khẩu",
					//	Description = $"{currentUser.UserName} đã reset mật khẩu của tài khoản : {response.UserName}"

					//});
					return Ok(ResponseModel.Success(response, "Reset mật khẩu công !"));
				}
				else return Ok(ResponseModel.Error(null, "Reset mật khẩu thất bại !"));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError, "Không thể reset mật khẩu, vui lòng xem lại !");
			}
		}
		[HttpDelete]
		[Route("{id}")]
		[PermissionDescription("Xóa tài khoản")]
		public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
		{
			try
			{
				var response = await _userService.DeleteAsync(id);
				if (response != null)
				{
					//var currentUser = await _authService.CurrentUser();
					//await _actionLogService.CreateAsync(new ActionLogDto
					//{
					//	Title = "Xóa người dùng",
					//	Description = $"{currentUser.UserName} đã xóa người dùng : {response.UserName}"

					//});
					return Ok(ResponseModel.Success(response, "Xóa người dùng thành công !"));
				}
				else return Ok(ResponseModel.Error(null, "Xóa người dùng thất bại !"));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError, "Không thể xóa tài khoản, vui lòng xem lại !");
			}
		}
	}
}
