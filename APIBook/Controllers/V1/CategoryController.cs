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
    [GroupPermissionDescription("Quản lý danh sách danh mục")]

    public class CategoryController : ControllerBase
	{
		private readonly ILogger<CategoryController> _logger;
		private readonly ICategoryService _categoryService;
		
		public CategoryController(ILogger<CategoryController> logger,ICategoryService categoryService)
		{
			_logger= logger;
			_categoryService= categoryService;
		}

		[HttpGet]
		[Route("")]
		[PermissionDescription("Xem danh sách các danh mục")]

		public async Task<IActionResult> GetListAsync([FromQuery] FilterRequest request)
		{
			try
			{
				var response = await _categoryService.GetListAsync(request);
				return Ok(ResponseModel.Success(response));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError, "Không thể lấy dữ liệu danh mục !");
			}
		}
		

		[HttpGet]
		[Route("dropdown")]
		[PermissionDescription("Xem tất cả các danh mục")]

		public async Task<IActionResult> GetAllAsync()
		{
			try
			{
				var response = await _categoryService.GetAllAsync();
				return Ok(ResponseModel.Success(response));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError, "Không thể lấy dữ liệu danh mục !");
			}
		}

		[HttpGet]
		[Route("{id}")]
		[PermissionDescription("Xem chi tiết danh mục")]

		public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
		{
			try
			{
				var response = await _categoryService.GetByIdAsync(id);
				if (response == null) return Ok(ResponseModel.Error(null, "danh mục không tồn tại !"));
				else return Ok(ResponseModel.Success(response));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError, "Không thể lấy dữ liệu danh mục !");
			}
		}

		[HttpPost]
		[Route("")]
		[PermissionDescription("Tạo mới danh mục")]

		public async Task<IActionResult> CreateAsync([FromBody] CategoryDto request)
		{
			try
			{
				var response = await _categoryService.CreateAsync(request);
				if (response != null)
				{
					
					return Ok(ResponseModel.Success(response, "Tạo mới danh mục thành công !"));
				}
				else
				{
					return Ok(ResponseModel.Error(null, "Tạo mới danh mục thất bại do trùng thông tin danh mục !"));
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError, "Không thể tạo danh mục, vui lòng xem lại !");
			}
		}

		[HttpPut]
		[Route("{id}")]
		[PermissionDescription("Chỉnh sửa danh mục")]

		public async Task<IActionResult> UpdateAsync([FromBody] CategoryDto request)
		{
			try
			{
				var response = await _categoryService.UpdateAsync(request);
				if (response != null)
				{
					return Ok(ResponseModel.Success(response, "Cập nhập danh mục thành công !"));
				}
				else
				{
					return Ok(ResponseModel.Error(null, "Cập nhật danh mục thất bại !"));
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError, "Không thể cập nhật danh mục, vui lòng xem lại !");
			}
		}

		[HttpDelete]
		[Route("{id}")]
		[PermissionDescription("Xóa danh mục")]

		public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
		{
			try
			{
				var response = await _categoryService.DeleteAsync(id);
				if (response != null)
				{
					return Ok(ResponseModel.Success(response, "Xóa danh mục thành công !"));
				}
				else
				{
					//await _hubContext.Clients.All.RemovedDoctor(ResponseModel.Error("Xóa danh mục thất bại !"));
					return Ok(ResponseModel.Error(null, "Xóa danh mục thất bại !"));
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				//await _hubContext.Clients.All.RemovedDoctor(ResponseModel.Error("Không thể xóa danh mục, vui lòng xem lại !"));
				return StatusCode(StatusCodes.Status500InternalServerError, "Không thể xóa danh mục, vui lòng xem lại !");
			}
		}
	}
}
