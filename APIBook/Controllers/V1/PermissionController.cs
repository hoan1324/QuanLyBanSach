using Api.Dtos;
using Api.Services;
using APIBook.Attributes;
using APIBook.Dtos.Permission;
using APIBook.Services;
using Azure;
using CommonHelper.Enum;
using CommonHelper.Helpers;
using CommonHelper.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Data;
using System.Reflection;

namespace Api.Controllers.V1
{
	[Route("v1/[controller]")]
	[ApiController]
	[Authorize]
	[UserAuthorize]
    [GroupPermissionDescription("Quản lý danh sách quyền")]

    public class PermissionController : ControllerBase
	{
		private readonly IPermissionService _permissionService;
		private readonly ILogger<PermissionController> _logger;
		//private readonly IActionLogService _actionLogService;
		private readonly IAuthService _authService;

		public PermissionController(IPermissionService permissionService, ILogger<PermissionController> logger,  IAuthService authService)
		{
			_permissionService = permissionService;
			_logger = logger;
			//_actionLogService = actionLogService;
			_authService = authService;
		}



		[HttpGet]
		[Route("")]
		[PermissionDescription("Xem danh sách quyền")]
		public async Task<IActionResult> GetPermissions()
		{
			try
			{
				return Ok(ResponseModel.Success(await _permissionService.GetPermissions()));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError, "Không xem danh sách quyền, vui lòng xem lại !");
			}
		}

        [HttpGet]
        [Route("group-permission")]
        [PermissionDescription("Xem danh sách nhóm quyền")]
        public async Task<IActionResult> GetGroupPermission()
        {
            try
            {
                return Ok(ResponseModel.Success(await _permissionService.GetGroupPermission()));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Không xem danh sách nhóm quyền, vui lòng xem lại !");
            }
        }

        [HttpPost]
		[Route("init")]
		[PermissionDescription("Tạo quyền mặc định")]
		public async Task<IActionResult> InitPermission()
		{
			try
			{
				Assembly asm = Assembly.GetExecutingAssembly();
				var listController = asm.GetTypes()
					.Where(type => typeof(ControllerBase).IsAssignableFrom(type))
					.Where(m => m.CustomAttributes.Any(n => n.AttributeType == typeof(GroupPermissionDescriptionAttribute)))
					.Select(n => new GroupPermissionDto
					{
						Id = Guid.Empty,
						Code = n.Name.Replace("Controller", ""),
						Name = ((GroupPermissionDescriptionAttribute)n.GetCustomAttribute(typeof(GroupPermissionDescriptionAttribute)))?.Description,
						Status = (int)PermissionStatusEnum.Active
					}).Distinct().ToList();

				var controllerActionList = asm.GetTypes()
						.Where(type => typeof(ControllerBase).IsAssignableFrom(type))
						.SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
						.Where(m => !m.GetCustomAttributes(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute), true).Any())
						.Where(m => m.CustomAttributes.Any(n => n.AttributeType == typeof(PermissionDescriptionAttribute)))
						.Select(x => new PermissionDto
						{
							Code = x.DeclaringType.Name.Replace("Controller", "") + "-" + x.Name,
							Id = Guid.Empty,
							Name = ((PermissionDescriptionAttribute)x.GetCustomAttribute(typeof(PermissionDescriptionAttribute)))?.Description,
							Status = (int)PermissionStatusEnum.Active,
							Method=(AttributeHelper.GetMethodEnum(x.GetCustomAttribute<HttpMethodAttribute>()?.HttpMethods.FirstOrDefault()))
                        })
						.OrderBy(x => x.Code).Distinct().ToList();
				var response = await _permissionService.InitRole( controllerActionList,listController);
				//var currentUser = await _authService.CurrentUser();
				//await _actionLogService.CreateAsync(new ActionLogDto
				//{
				//	Title = "Tạo quyền mặc định",
				//	Description = $"{currentUser.UserName} đã tạo quyền mặc định : {listController.Select(item => item.GroupPermissionName)}"
				//});
				return Ok(ResponseModel.Success(response));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError, "Không thể tạo các quyền đã được định nghĩa, vui lòng xem lại !");
			}
		}

		[HttpPut]
		[Route("group/{roleId}")]
		[PermissionDescription("Phân quyền vai trò")]
		public async Task<IActionResult> UpdatePermissionGroup([FromRoute] Guid roleId, [FromBody] List<PermissionDto> request)
		{
			try
			{
				var permissionUpdate = await _permissionService.UpdateRolePermissions(roleId, request);
				var currentUser = await _authService.CurrentUser();
				//await _actionLogService.CreateAsync(new ActionLogDto
				//{
				//	Title = "Phân quyền nhóm người dùng",
				//	Description = $"{currentUser.UserName} đã phân quyền nhóm người dùng : {permissionUpdate.Select(item => item.PermissionName)}"
				//});
				return Ok(ResponseModel.Success(permissionUpdate));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError, "Không thể phân quyền vai trò, vui lòng xem lại !");
			}
		}

		[HttpGet]
		[Route("group/{roleId}")]
		[PermissionDescription("Xem quyền nhóm người dùng")]
		public async Task<IActionResult> PermissionGroup([FromRoute] Guid roleId)
		{
			try
			{
				return Ok(ResponseModel.Success(await _permissionService.GetRolePermissions(roleId)));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError, "Không thể xem quyền vai trò, vui lòng xem lại !");
			}
		}

		[HttpPut]
		[Route("user/{userId}")]
		[PermissionDescription("Phân quyền người dùng")]
		public async Task<IActionResult> UpdatePermissionUser([FromRoute] Guid userId, [FromBody] List<PermissionDto> request)
		{
			try
			{
				var permissionUpdate = await _permissionService.UpdateUserPermissions(userId, request);
				//var currentUser = await _authService.CurrentUser();
				//await _actionLogService.CreateAsync(new ActionLogDto
				//{
				//	Title = "Phân quyền người dùng",
				//	Description = $"{currentUser.UserName}đã phân quyền người dùng : {permissionUpdate.Select(item => item.PermissionName)}"
				//});
				return Ok(ResponseModel.Success(permissionUpdate));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError, "Không thể phân quyền người dùng, vui lòng xem lại !");
			}
		}

		[HttpGet]
		[Route("user/{userId}")]
		[PermissionDescription("Xem quyền người dùng")]
		public async Task<IActionResult> PermissionUser([FromRoute] Guid userId)
		{
			try
			{
				return Ok(ResponseModel.Success(await _permissionService.GetUserPermissions(userId)));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError, "Không thể xem quyền người dùng, vui lòng xem lại !");
			}
		}
	}
}
