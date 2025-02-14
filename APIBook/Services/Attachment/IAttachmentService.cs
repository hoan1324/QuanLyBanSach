using APIBook.Dtos;
using CommonHelper.Models;

namespace Api.Services
{
    public interface IAttachmentService
    {
        //Task<List<AttachmentDto>> GetMyFiles();
        Task<PaginationModel<AttachmentDto>> GetListAsync(FilterRequest request);
        Task<AttachmentDto> GetByIdAsync(Guid AttachmentId);
        Task<AttachmentDto> CreateAsync(AttachmentDto request);
        Task<List<AttachmentDto>> CreateManyAsync(List<AttachmentDto> request);
        Task<AttachmentDto> UpdateAsync(AttachmentDto request);
        Task<AttachmentDto> DeleteAsync(Guid AttachmentId);

	}
}
