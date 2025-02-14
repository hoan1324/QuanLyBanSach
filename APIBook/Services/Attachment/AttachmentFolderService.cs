using Api.Domain.Contracts;
using APIBook.Dtos;
using AutoMapper;
using CommonHelper.Helpers;
using CommonHelper.Models;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;

namespace Api.Services
{
	public class AttachmentFolderService : IAttachmentFolderService
	{
		private readonly IAttachmentFolderRepository _attachmentFolderRepository;
		private readonly IAttachmentRepository _attachmentRepository;
		private readonly IMapper _mapper;
		private readonly IWebHostEnvironment _webHostEnvironment;
		public AttachmentFolderService(IAttachmentFolderRepository attachmentFolderRepository, IAttachmentRepository attachmentRepository, IMapper mapper, IWebHostEnvironment webHostEnvironment)
		{
			_attachmentFolderRepository = attachmentFolderRepository;
			_attachmentRepository = attachmentRepository;
			_mapper = mapper;
			_webHostEnvironment = webHostEnvironment;
		}
		public async Task<AttachmentFolderDto> CreateAsync(AttachmentFolderDto request)
		{
			//var currentUser = await _authService.CurrentUser();
			//request.CreatedBy = currentUser.Id;
			var attachment = _mapper.Map<AttachmentFolderDto, ApiDomain.Entity.AttachmentFolder>(request);
			return _mapper.Map<ApiDomain.Entity.AttachmentFolder, AttachmentFolderDto>(
				await _attachmentFolderRepository.CreateAsync(attachment));
		}


		public async Task<AttachmentFolderDto> DeleteAsync(Guid id)
		{
			var attachmentFolder = await _attachmentFolderRepository.GetByIdAsync(id);
			if (attachmentFolder == null)
				return null;

			var attachmentsInFolder = await _attachmentFolderRepository.GetAttachmentsByFolder(id, null, null);
			if (attachmentsInFolder.Any())
			{
				var fileUrls = attachmentsInFolder.Select(item => Path.Combine(_webHostEnvironment.WebRootPath, item.Url)).Distinct().ToList();

				bool allFilesDeleted = await FileHelper.DeleteFilesAsync(fileUrls);
				if (!allFilesDeleted)
				{
					// Ghi log nếu cần hoặc trả về thông báo lỗi
					return null;
				}
			}

			// Xóa folder sau khi tất cả file đã được xóa thành công
			var deletedFolder = await _attachmentFolderRepository.DeleteAsync(id);

			return _mapper.Map<ApiDomain.Entity.AttachmentFolder, AttachmentFolderDto>(deletedFolder);
		}


		public async Task<List<AttachmentFolderDto>> GetAllAsync()
		{
			return _mapper.Map<List<AttachmentFolderDto>>(await _attachmentFolderRepository.GetAll());
		}

		public async Task<PaginationModel<AttachmentDto>> GetAttachmentsInFolderAsync(AttachmentInFolderDto request)
		{
			if (request?.Ext?.Count == 1)
			{
				var dataExt = request.Ext[0];
				if (dataExt.StartsWith("[") && dataExt.EndsWith("]"))
				{
					request.Ext = JsonConvert.DeserializeObject<List<string>>(dataExt);
				}

			}
			//return _mapper.Map<List<Attachment>, List<AttachmentDto>>(await _attachmentFolderRepository.GetAttachmentsByFolder(request.FolderId, request.TextSearch, request.Ext));
			return _mapper.Map<PaginationModel<ApiDomain.Entity.Attachment>, PaginationModel<AttachmentDto>>(await _attachmentFolderRepository.GetPageAttachmentsByFolder(request.FolderId, request.TextSearch, request.Ext, request.PageIndex, 21));
		}

		//public async Task<List<AttachmentFolderDto>> GetMyFolderAsync()
		//{
		//    //var currentUser = await _authService.CurrentUser();
		//   // var attachments = await _attachmentFolderRepository.GetByUser(currentUser.Id.Value);
		//    var folders = _mapper.Map<List<AttachmentFolder>, List<AttachmentFolderDto>>(attachments);
		//    if (folders?.Count > 0) return folders;
		//    else
		//    {
		//        var defaultFolder = await CreateAsync(new AttachmentFolderDto
		//        {
		//            Name = "Thư mục gốc",
		//            Description = "Thư mục gốc của khách hàng",
		//        });
		//        return new List<AttachmentFolderDto> { defaultFolder };
		//    }
		//}

		public async Task<AttachmentFolderDto> UpdateAsync(AttachmentFolderDto request)
		{
			//var currentUser = await _authService.CurrentUser();
			request.ModifiedDate = DateTime.Now;
			// request.ModifiedBy = currentUser.Id;
			var attachment = _mapper.Map<AttachmentFolderDto, ApiDomain.Entity.AttachmentFolder>(request);
			return _mapper.Map<ApiDomain.Entity.AttachmentFolder, AttachmentFolderDto>(
				await _attachmentFolderRepository.UpdateAsync(attachment));
		}
	}
}
