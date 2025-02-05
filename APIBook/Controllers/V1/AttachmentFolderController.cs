using Api.Services;
using APIBook.Dtos;
using CommonHelper.Constant;
using CommonHelper.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIBook.Controllers.V1
{
	[Route("v1/[controller]")]
	[ApiController]
	public class AttachmentFolderController : ControllerBase
	{
		private readonly IWebHostEnvironment _webHostEnvironment;
		private readonly ILogger<AttachmentFolderController> _logger;
		private readonly IAttachmentFolderService _attachmentFolderService;
		private readonly IAttachmentService _attachmentService;

		public AttachmentFolderController(ILogger<AttachmentFolderController> logger, IAttachmentFolderService attachmentFolderService, IAttachmentService attachmentService, IWebHostEnvironment webHostEnvironment)
		{
			_logger = logger;
			_attachmentFolderService = attachmentFolderService;
			_webHostEnvironment = webHostEnvironment;
			_attachmentService = attachmentService;

		}
		[HttpGet]
		[Route("files")]
		public async Task<IActionResult> GetAttachmentsInFolderAsync([FromQuery] AttachmentInFolderDto request)
		{
			try
			{
				var response = await _attachmentFolderService.GetAttachmentsInFolderAsync(request);
				return Ok(ResponseModel.Success(response));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError, "Không thể lấy dữ liệu thư mục thuộc thư mục này !");
			}
		}
		[HttpGet]
		[Route("dropdown")]
		public async Task<IActionResult> GetAllAsync()
		{
			try
			{
				var response = await _attachmentFolderService.GetAllAsync();
				return Ok(ResponseModel.Success(response));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError, "Không thể lấy dữ liệu thư mục !");
			}
		}
		//[HttpGet]
		//[Route("my-folders")]
		//public async Task<IActionResult> GetMyFoldersAsync()
		//{
		//	try
		//	{
		//		var response = await _attachmentFolderService.GetMyFolderAsync();
		//		return Ok(ResponseModel.Success(response));
		//	}
		//	catch (Exception ex)
		//	{
		//		_logger.LogError(ex.Message);
		//		return StatusCode(StatusCodes.Status500InternalServerError, "Không thể lấy dữ liệu thư mục !");
		//	}
		//}

		[HttpPost]
		[Route("")]
		public async Task<IActionResult> CreateAsync([FromBody] AttachmentFolderDto request)
		{
			try
			{
				var response = await _attachmentFolderService.CreateAsync(request);
				if (response != null)
				{
					return Ok(ResponseModel.Success(response, "Tạo mới thư mục thành công !"));
				}
				else return Ok(ResponseModel.Error(null, "Tạo mới thư mục thất bại do trùng tên thư mục !"));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError, "Không thể tạo thư mục, vui lòng xem lại !");
			}
		}

		[HttpPut]
		[Route("{id}")]
		public async Task<IActionResult> UpdateAsync([FromBody] AttachmentFolderDto request)
		{
			try
			{
				var response = await _attachmentFolderService.UpdateAsync(request);
				if (response != null)
				{
					return Ok(ResponseModel.Success(response, "Cập nhật thư mục thành công !"));
				}
				else return Ok(ResponseModel.Error(null, "Cập nhật thư mục thất bại !"));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError, "Không thể cập nhật thư mục, vui lòng xem lại !");
			}
		}

		[HttpDelete]
		[Route("{id}")]
		public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
		{
			try
			{
				var response = await _attachmentFolderService.DeleteAsync(id);
				if (response != null)
				{
					return Ok(ResponseModel.Success(response, "Xóa thư mục thành công !"));
				}
				else return Ok(ResponseModel.Error(null, "Xóa thư mục thất bại !"));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError, "Không thể xóa thư mục, vui lòng xem lại !");
			}
		}

		[HttpPut]
		[Route("{id}/files")]
		[DisableRequestSizeLimit]
		public async Task<IActionResult> UploadFiles([FromRoute] Guid id)
		{
			try
			{
				//var currentUser = await _authService.CurrentUser();
				List<AttachmentDto> listAttachment = new();
				var files = Request.Form.Files;
				if (files != null && files.Count > 0)
				{
					var listTask = new List<Task<AttachmentDto>>();
					foreach (var item in files)
					{
						listTask.Add(Task.Run(async () => {
							var fileName = Path.GetFileNameWithoutExtension(item.FileName) + DateTime.Now.ToString("ddMMyyyyHHmmss") + Path.GetExtension(item.FileName);
							var absolutePath = Path.Combine("uploads", fileName);
							var fullPath = Path.Combine(_webHostEnvironment.WebRootPath, absolutePath);
							using (var stream = new FileStream(fullPath, FileMode.Create))
							{
								await item.CopyToAsync(stream);
								return new AttachmentDto
								{
									AttachmentFolderId = id,
									//CreatedBy = currentUser.Id,
									Extention = Path.GetExtension(item.FileName),
									Name = item.FileName,
									Size = item.Length,
									Url = absolutePath
								};
							}
						}));
					}
					if (listTask?.Count > 0)
					{
						var atttachments = await Task.WhenAll(listTask);
						if (atttachments?.Length > 0)
						{
							var createAttachment = await _attachmentService.CreateManyAsync(atttachments.ToList());
							
							return Ok(ResponseModel.Success(createAttachment));
						}
					}
					return Ok(ResponseModel.Error("Không thể tải lên tệp, vui lòng xem lại !"));
				}
				return BadRequest("Bạn chưa tải lên tệp !");
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError, "Không thể tải lên tệp, vui lòng xem lại !");
			}
		}

		[HttpPut]
		[Route("{id}/file")]
		[DisableRequestSizeLimit]
		public async Task<IActionResult> UploadFile([FromRoute] Guid id)
		{
			try
			{
				//var currentUser = await _authService.CurrentUser();
				List<AttachmentDto> listAttachment = new();
				var files = Request.Form.Files;
				if (files != null && files.Count > 0)
				{
					var listTask = new List<Task<AttachmentDto>>();
					var fileName = StringHelper.BuildNewsUnsignName(Path.GetFileNameWithoutExtension(files[0].FileName)) + DateTime.Now.ToString("ddMMyyyyHHmmss") + Path.GetExtension(files[0].FileName);
					var absolutePath = Path.Combine("uploads", fileName);
					var fullPath = Path.Combine(_webHostEnvironment.WebRootPath, absolutePath);
					
					using (var stream = new FileStream(fullPath, FileMode.Create))
					{
						await files[0].CopyToAsync(stream);
						var attachment = new AttachmentDto
						{
							AttachmentFolderId = id,
							//CreatedBy = currentUser.Id,
							Extention = Path.GetExtension(files[0].FileName),
							Name = files[0].FileName,
							Size = files[0].Length,
							Url = absolutePath
						};
						var createAttachment = await _attachmentService.CreateAsync(attachment);
						return Ok(ResponseModel.Success(createAttachment));
					}
				}
				return BadRequest("Bạn chưa tải lên tệp !");
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError, "Không thể tải lên tệp, vui lòng xem lại !");
			}
		}
	}
}
