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
	public class StaffController : ControllerBase
	{
		private readonly ILogger<StaffController> _logger;
		private readonly IStaffService _staffService;
		
		public StaffController(ILogger<StaffController> logger,IStaffService staffService)
		{
			_logger= logger;
			_staffService= staffService;
		}

		[HttpGet]
		[Route("")]
		public async Task<IActionResult> GetListAsync([FromQuery] FilterRequest request)
		{
			try
			{
				var response = await _staffService.GetListAsync(request);
				return Ok(ResponseModel.Success(response));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError, "Không thể lấy dữ liệu nhân viên !");
			}
		}

		[HttpGet]
		[Route("dropdown")]
		public async Task<IActionResult> GetAllAsync()
		{
			try
			{
				var response = await _staffService.GetAllAsync();
				return Ok(ResponseModel.Success(response));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError, "Không thể lấy dữ liệu nhân viên !");
			}
		}

		[HttpGet]
		[Route("{id}")]
		public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
		{
			try
			{
				var response = await _staffService.GetByIdAsync(id);
				if (response == null) return Ok(ResponseModel.Error(null, "nhân viên không tồn tại !"));
				else return Ok(ResponseModel.Success(response));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError, "Không thể lấy dữ liệu nhân viên !");
			}
		}

		[HttpPost]
		[Route("")]
		public async Task<IActionResult> CreateAsync([FromBody] StaffDto request)
		{
			try
			{
				var response = await _staffService.CreateAsync(request);
				if (response != null)
				{
					
					return Ok(ResponseModel.Success(response, "Tạo mới nhân viên thành công !"));
				}
				else
				{
					return Ok(ResponseModel.Error(null, "Tạo mới nhân viên thất bại do trùng thông tin nhân viên !"));
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError, "Không thể tạo nhân viên, vui lòng xem lại !");
			}
		}

		[HttpPut]
		[Route("{id}")]
		public async Task<IActionResult> UpdateAsync([FromBody] StaffDto request)
		{
			try
			{
				var response = await _staffService.UpdateAsync(request);
				if (response != null)
				{
					return Ok(ResponseModel.Success(response, "Cập nhập nhân viên thành công !"));
				}
				else
				{
					return Ok(ResponseModel.Error(null, "Cập nhật nhân viên thất bại !"));
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError, "Không thể cập nhật nhân viên, vui lòng xem lại !");
			}
		}

		[HttpDelete]
		[Route("{id}")]
		public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
		{
			try
			{
				var response = await _staffService.DeleteAsync(id);
				if (response != null)
				{
					return Ok(ResponseModel.Success(response, "Xóa nhân viên thành công !"));
				}
				else
				{
					//await _hubContext.Clients.All.RemovedDoctor(ResponseModel.Error("Xóa nhân viên thất bại !"));
					return Ok(ResponseModel.Error(null, "Xóa nhân viên thất bại !"));
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				//await _hubContext.Clients.All.RemovedDoctor(ResponseModel.Error("Không thể xóa nhân viên, vui lòng xem lại !"));
				return StatusCode(StatusCodes.Status500InternalServerError, "Không thể xóa nhân viên, vui lòng xem lại !");
			}
		}
	}
}
