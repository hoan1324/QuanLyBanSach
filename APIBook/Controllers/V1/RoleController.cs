using APIBook.Attributes;
using APIBook.Dtos;
using APIBook.Services;
using ApiDomain.Entity;
using CommonHelper.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIBook.Controllers.V1
{
	[Route("v1/[controller]")]
	[ApiController]
	[Authorize]
	[UserAuthorize]
	public class RoleController : ControllerBase
	{
		private readonly ILogger<RoleController> _logger;
		private readonly IRoleService _roleService;
		private readonly IUserService _userService;
		//private readonly IActionLogService _actionLogService;
		private readonly IAuthService _authService;

		public RoleController(ILogger<RoleController> logger, IRoleService roleService, IUserService userService,  IAuthService authService)
		{
			_logger = logger;
			_roleService = roleService;
			_userService = userService;
			//_actionLogService = actionLogService;
			_authService = authService;
		}

		[HttpGet]
		[Route("")]
		[PermissionDescription("Xem danh sách các vai trò")]
		public async Task<IActionResult> GetListAsync([FromQuery] FilterRequest request)
		{
			try
			{
				var response = await _roleService.GetListAsync(request);
				return Ok(ResponseModel.Success(response));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError, "Không thể lấy dữ liệu vai trò !");
			}
		}

		[HttpGet]
		[Route("dropdown")]
		[PermissionDescription("Xem tất cả các vai trò")]
		public async Task<IActionResult> GetAllAsync()
		{
			try
			{
				var response = await _roleService.GetAllAsync();
				return Ok(ResponseModel.Success(response));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError, "Không thể lấy dữ liệu vai trò !");
			}
		}
		[HttpGet]
		[Route("{code}/users")]
		[PermissionDescription("Xem danh sách tài khoản trong 1 vai trò")]
		public async Task<IActionResult> GetByPositionAsync([FromRoute] string code)
		{
			try
			{
				var response = await _userService.GetByPositionAsync(code);
				if (response == null) return Ok(ResponseModel.Error(null, "Nhóm người dùng/người dùng không tồn tại !"));
				else return Ok(ResponseModel.Success(response));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError, "Không thể lấy dữ liệu người dùng !");
			}
		}

		[HttpGet]
		[Route("{id}")]
		[PermissionDescription("Xem chi tiết vai trò")]
		public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
		{
			try
			{
				var response = await _roleService.GetByIdAsync(id);
				if (response == null) return Ok(ResponseModel.Error(null, "Vai trò không tồn tại !"));
				else return Ok(ResponseModel.Success(response));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError, "Không thể lấy dữ liệu vai trò !");
			}
		}

		[HttpPost]
		[Route("")]
		[PermissionDescription("Thêm vai trò")]
		public async Task<IActionResult> CreateAsync([FromBody] RoleDto request)
		{
			try
			{
				var response = await _roleService.CreateAsync(request);
				if (response != null)
				{
					//var currentUser = await _authService.CurrentUser();
					//await _actionLogService.CreateAsync(new ActionLogDto
					//{
					//	Title = "Tạo mới nhóm tài khoản",
					//	Description = $"{currentUser.UserName} đã tạo mới nhóm tài khoản : {response.RoleName}"

					//});

					return Ok(ResponseModel.Success(response, "Tạo mới vai trò thành công !"));
				}
				else return Ok(ResponseModel.Error(null, "Tạo mới vai trò thất bại do trùng tên nhóm tài khoản !"));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError, "Không thể tạo tài khoản, vui lòng xem lại !");
			}
		}

		[HttpPut]
		[Route("{id}")]
		[PermissionDescription("Cập nhật vai trò")]
		public async Task<IActionResult> UpdateAsync([FromBody] RoleDto request)
		{
			try
			{
				var response = await _roleService.UpdateAsync(request);
				if (response != null)
				{
					//var currentUser = await _authService.CurrentUser();
					//await _actionLogService.CreateAsync(new ActionLogDto
					//{
					//	Title = "Cập nhật nhóm tài khoản",
					//	Description = $"{currentUser.UserName} đã cập nhật nhóm tài khoản : {response.RoleName}"

					//});
					return Ok(ResponseModel.Success(response, "Cập nhật vai trò thành công !"));
				}
				else return Ok(ResponseModel.Error(null, "Cập nhật vai trò thất bại !"));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError, "Không thể cập nhật nhóm tài khoản, vui lòng xem lại !");
			}
		}

		[HttpDelete]
		[Route("{id}")]
		[PermissionDescription("Xóa vai trò")]
		public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
		{
			try
			{
				var response = await _roleService.DeleteAsync(id);
				if (response != null)
				{
					//var currentUser = await _authService.CurrentUser();
					//await _actionLogService.CreateAsync(new ActionLogDto
					//{
					//	Title = "Xóa nhóm tài khoản",
					//	Description = $"{currentUser.UserName} đã xóa nhóm tài khoản : {response.RoleName}"

					//});
					return Ok(ResponseModel.Success(response, "Xóa vai trò thành công !"));
				}
				else return Ok(ResponseModel.Error(null, "Xóa vai trò thất bại !"));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError, "Không thể xóa vai trò, vui lòng xem lại !");
			}
		}

	}
}
