using ApiDomain.Entity;
using CommonHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Contracts
{
    public interface IAttachmentFolderRepository
    {
        Task<List<AttachmentFolder>> GetByUser(Guid userId);
        Task<List<Attachment>> GetAttachmentsByFolder(Guid folderId, string textSearch, List<string> ext);
        Task<PaginationModel<Attachment>> GetPageAttachmentsByFolder(Guid folderId, string textSearch, List<string>? ext, int pageIndex = 1, int pageSize = 21);
        Task<List<AttachmentFolder>> GetAll();
		Task<AttachmentFolder> CreateAsync(AttachmentFolder request);
        Task<AttachmentFolder> UpdateAsync(AttachmentFolder request);
        Task<AttachmentFolder> DeleteAsync(Guid id);
    }
}
