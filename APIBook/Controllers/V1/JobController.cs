using APIBook.Dtos;
using APIBook.Services;
using ApiDomain.Entity;
using CommonHelper.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIBook.Controllers.V1
{
	[Route("v1/[controller]")]
	[ApiController]
	public class JobController : ControllerBase
	{
		private readonly ILogger<JobController> _logger;
		private readonly IJobService _jobService;
		
		public JobController(ILogger<JobController> logger,IJobService jobService)
		{
			_logger= logger;
			_jobService= jobService;
		}

		[HttpGet]
		[Route("")]
		public async Task<IActionResult> GetListAsync([FromQuery] FilterRequest request)
		{
			try
			{
				var response = await _jobService.GetListAsync(request);
				return Ok(ResponseModel.Success(response));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError, "Không thể lấy dữ liệu công việc !");
			}
		}
		

		[HttpGet]
		[Route("dropdown")]
		public async Task<IActionResult> GetAllAsync()
		{
			try
			{
				var response = await _jobService.GetAllAsync();
				return Ok(ResponseModel.Success(response));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError, "Không thể lấy dữ liệu công việc !");
			}
		}

		[HttpGet]
		[Route("{id}")]
		public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
		{
			try
			{
				var response = await _jobService.GetByIdAsync(id);
				if (response == null) return Ok(ResponseModel.Error(null, "công việc không tồn tại !"));
				else return Ok(ResponseModel.Success(response));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError, "Không thể lấy dữ liệu công việc !");
			}
		}

		[HttpPost]
		[Route("")]
		public async Task<IActionResult> CreateAsync([FromBody] JobDto request)
		{
			try
			{
				var response = await _jobService.CreateAsync(request);
				if (response != null)
				{
					
					return Ok(ResponseModel.Success(response, "Tạo mới công việc thành công !"));
				}
				else
				{
					return Ok(ResponseModel.Error(null, "Tạo mới công việc thất bại do trùng thông tin công việc !"));
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError, "Không thể tạo công việc, vui lòng xem lại !");
			}
		}

		[HttpPut]
		[Route("{id}")]
		public async Task<IActionResult> UpdateAsync([FromBody] JobDto request)
		{
			try
			{
				var response = await _jobService.UpdateAsync(request);
				if (response != null)
				{
					return Ok(ResponseModel.Success(response, "Cập nhập công việc thành công !"));
				}
				else
				{
					return Ok(ResponseModel.Error(null, "Cập nhật công việc thất bại !"));
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError, "Không thể cập nhật công việc, vui lòng xem lại !");
			}
		}

		[HttpDelete]
		[Route("{id}")]
		public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
		{
			try
			{
				var response = await _jobService.DeleteAsync(id);
				if (response != null)
				{
					return Ok(ResponseModel.Success(response, "Xóa công việc thành công !"));
				}
				else
				{
					//await _hubContext.Clients.All.RemovedDoctor(ResponseModel.Error("Xóa công việc thất bại !"));
					return Ok(ResponseModel.Error(null, "Xóa công việc thất bại !"));
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				//await _hubContext.Clients.All.RemovedDoctor(ResponseModel.Error("Không thể xóa công việc, vui lòng xem lại !"));
				return StatusCode(StatusCodes.Status500InternalServerError, "Không thể xóa công việc, vui lòng xem lại !");
			}
		}
	}
}
