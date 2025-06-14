﻿using Api.Services;
using APIBook.Attributes;
using APIBook.Dtos;
using CommonHelper.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace APIBook.Controllers.V1
{
	[Route("v1/[controller]")]
	[ApiController]
	[Authorize]
	[UserAuthorize]
	[GroupPermissionDescription("Quản lý danh sách tệp")]
	public class AttachmentController : ControllerBase
	{
		private readonly IWebHostEnvironment _webHostEnvironment;
		private readonly ILogger<AttachmentController> _logger;
		private readonly IAttachmentService _attachmentService;

		public AttachmentController(ILogger<AttachmentController> logger, IAttachmentService attachmentService, IWebHostEnvironment webHostEnvironment)
		{
			_logger = logger;
			_attachmentService = attachmentService;
			_webHostEnvironment = webHostEnvironment;

		}
		[HttpGet]
		[Route("")]
		[PermissionDescription("Xem danh sách các tệp đính kèm")]
		public async Task<IActionResult> GetListAsync([FromQuery] FilterRequest request)
		{
			try
			{
				var response = await _attachmentService.GetListAsync(request);
				return Ok(ResponseModel.Success(response));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError, "Không thể lấy dữ liệu tệp !");
			}
		}

		//[HttpGet]
		//[Route("my-files")]
		//public async Task<IActionResult> GetMyFileAsync()
		//{
		//	try
		//	{
		//		var response = await _attachmentService.GetMyFiles();
		//		return Ok(ResponseModel.Success(response));
		//	}
		//	catch (Exception ex)
		//	{
		//		_logger.LogError(ex.Message);
		//		return StatusCode(StatusCodes.Status500InternalServerError, "Không thể lấy dữ liệu tệp !");
		//	}
		//}

		[HttpGet]
		[Route("{id}")]
		[PermissionDescription("Xem chi tiết tệp đính kèm")]
		public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
		{
			try
			{
				var response = await _attachmentService.GetByIdAsync(id);
				if (response == null) return Ok(ResponseModel.Error(null, "tệp không tồn tại !"));
				else return Ok(ResponseModel.Success(response));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError, "Không thể lấy dữ liệu tệp !");
			}
		}

		[HttpPost]
		[Route("")]
		[PermissionDescription("Tạo mới tệp đính kèm")]

		public async Task<IActionResult> CreateAsync([FromBody] AttachmentDto request)
		{
			try
			{
				var response = await _attachmentService.CreateAsync(request);
				if (response != null)
				{
					return Ok(ResponseModel.Success(response, "Tạo mới tệp thành công !"));
				}
				else return Ok(ResponseModel.Error(null, "Tạo mới tệp thất bại do trùng tên tệp !"));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError, "Không thể tạo tệp, vui lòng xem lại !");
			}
		}

		[HttpPut]
		[Route("{id}")]
		[PermissionDescription("Chỉnh sửa tệp đính kèm")]

		public async Task<IActionResult> UpdateAsync([FromBody] AttachmentDto request)
		{
			try
			{
				var response = await _attachmentService.UpdateAsync(request);
				if (response != null)
				{
					return Ok(ResponseModel.Success(response, "Cập nhật tệp thành công !"));
				}

				else return Ok(ResponseModel.Error(null, "Cập nhật tệp thất bại !"));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError, "Không thể cập nhật tệp, vui lòng xem lại !");
			}
		}

		[HttpDelete]
		[Route("{id}")]
		[PermissionDescription("Xóa tệp đính kèm")]

		public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
		{
			try
			{
				var response = await _attachmentService.DeleteAsync(id);
				if (response != null)
				{
					return Ok(ResponseModel.Success(response, "Xóa tệp thành công !"));
				}
				else return Ok(ResponseModel.Error(null, "Xóa tệp thất bại !"));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError, "Không thể xóa tệp, vui lòng xem lại !");
			}
		}
	}
}
