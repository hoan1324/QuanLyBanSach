using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiDomain.Entity;
using CommonHelper.Models;

namespace Api.Domain.Contracts
{
    public interface IAttachmentRepository
    {
        Task<List<Attachment>> GetAllAsync();

        Task<List<Attachment>> GetByUser(Guid userId);
        Task<PaginationModel<Attachment>> GetPaggination(PaginationRequestModel request);
        Task<Attachment> GetByIdAsync(Guid AttachmentId);
        Task<Attachment> CreateAsync(Attachment request);
        Task<List<Attachment>> CreateManyAsync(List<Attachment> request);
        Task<Attachment> UpdateAsync(Attachment request);
        Task<Attachment> DeleteAsync(Guid AttachmentId);
	}
}
