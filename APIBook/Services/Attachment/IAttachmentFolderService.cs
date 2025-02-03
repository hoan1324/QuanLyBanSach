
using APIBook.Dtos;
using CommonHelper.Models;

namespace Api.Services
{
    public interface IAttachmentFolderService
    {
		// Task<List<AttachmentFolderDto>> GetMyFolderAsync();
		Task<List<AttachmentFolderDto>> GetAllAsync();

		Task<PaginationModel<AttachmentDto>> GetAttachmentsInFolderAsync(AttachmentInFolderDto request);
        Task<AttachmentFolderDto> CreateAsync(AttachmentFolderDto request);
        Task<AttachmentFolderDto> UpdateAsync(AttachmentFolderDto request);
        Task<AttachmentFolderDto> DeleteAsync(Guid id);
    }
}
