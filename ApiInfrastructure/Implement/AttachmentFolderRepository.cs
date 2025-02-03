using Api.Domain.Contracts;
using ApiDomain.Base;
using ApiDomain.Entity;
using CommonHelper.Helpers;
using CommonHelper.Models;

using Microsoft.EntityFrameworkCore;

namespace Api.Infrastructure.Implement
{
    public class AttachmentFolderRepository : IAttachmentFolderRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<AttachmentFolder> _attachmentFolderRepo;
        private readonly IRepository<Attachment> _attachmentRepo;
        public AttachmentFolderRepository(IUnitOfWork unitOfWork, IRepository<AttachmentFolder> attachmentFolderRepo, IRepository<Attachment> attachmentRepo)
        {
            _unitOfWork = unitOfWork;
            _attachmentFolderRepo = attachmentFolderRepo;
            _attachmentRepo = attachmentRepo;
        }
        public async Task<AttachmentFolder> CreateAsync(AttachmentFolder request)
        {
            request.Id = Guid.NewGuid();
            var attachment = await _attachmentFolderRepo.AddAsync(request);
            await _unitOfWork.SaveAsync();
            return attachment;
        }

        public async Task<AttachmentFolder> DeleteAsync(Guid id)
        {
            var attachmentFolder = await _attachmentFolderRepo.FindAsync(id);
            if (attachmentFolder != null)
            {
                await _attachmentRepo.DeleteByExpressionAsync(n => n.AttachmentFolderId == id);
                await _attachmentFolderRepo.DeleteAsync(attachmentFolder);
                await _unitOfWork.SaveAsync();
                return attachmentFolder;
            }
            return null;
        }

        public async Task<List<Attachment>> GetAttachmentsByFolder(Guid folderId, string textSearch, List<string>? ext)
        {
            return await _attachmentRepo
                .GetByExpression(n => n.AttachmentFolderId == folderId 
                                      && (string.IsNullOrEmpty(textSearch) || n.Name.Contains(textSearch)) 
                                      && (ext == null || ext.Count <= 0 || ext.Any(m => n.Name.EndsWith(m))))
                .AsNoTracking()
                .OrderByDescending(n => n.CreatedDate).ToListAsync();
        }

        public async Task<PaginationModel<Attachment>> GetPageAttachmentsByFolder(Guid folderId, string textSearch, List<string>? ext, int pageIndex = 1, int pageSize = 21)
        {
            var query = _attachmentRepo
                .GetByExpression(n => n.AttachmentFolderId == folderId
                                      && (string.IsNullOrEmpty(textSearch) || n.Name.Contains(textSearch))
                                      && (ext == null || ext.Count <= 0 || ext.Any(m => n.Name.EndsWith(m))))
                .AsNoTracking()
                .OrderByDescending(n => n.CreatedDate);
            return new PaginationModel<Attachment>
            {
                TotalRow = await query.CountAsync(),
                Data = await query.Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToListAsync()
            };
		}


		public async Task<List<AttachmentFolder>> GetByUser(Guid userId)
        {
            return await _attachmentFolderRepo.GetByExpression(n => n.CreatedBy == userId).AsNoTracking().OrderBy(n => n.CreatedDate).ToListAsync();
        }

        public async Task<AttachmentFolder> UpdateAsync(AttachmentFolder request)
        {
            var attachmentFolder = await _attachmentFolderRepo.FindAsync(request.Id);
            if (attachmentFolder != null)
            {
                TypeHelper.NormalMapping(request, attachmentFolder, "Id", "CreatedDate", "CreatedBy");
                var attachmentFolderUpdate = await _attachmentFolderRepo.UpdateAsync(attachmentFolder);
                await _unitOfWork.SaveAsync();
                return attachmentFolderUpdate;
            }

            return null;
        }

        public async Task<List<AttachmentFolder>> GetAll ()
		{
            return await _attachmentFolderRepo.GetAll().AsNoTracking().ToListAsync();
		}
	}
}
