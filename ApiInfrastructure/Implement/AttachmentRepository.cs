using Api.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApiDomain.Entity;
using ApiDomain.Base;
using CommonHelper.Models;
using CommonHelper.Helpers;

namespace Api.Infrastructure.Implement
{
    public class AttachmentRepository : IAttachmentRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Attachment> _attachmentRepo;
        public AttachmentRepository(IUnitOfWork unitOfWork, IRepository<Attachment> attachmentRepo)
        {
            _unitOfWork = unitOfWork;
            _attachmentRepo = attachmentRepo;
        }
        public async Task<List<Attachment>> GetAllAsync()
        {
            return await _attachmentRepo.GetAll().AsNoTracking().ToListAsync();
        }

        public async Task<List<Attachment>> GetByUser(Guid userId)
        {
            return await _attachmentRepo.GetByExpression(n => n.CreatedBy == userId).AsNoTracking().ToListAsync();
        }

        public async Task<PaginationModel<Attachment>> GetPaggination(PaginationRequestModel request)
        {
			return await PaginatedList<Attachment>.CreatePaginatedList(_attachmentRepo.GetAll(), request);
        }

        public async Task<Attachment?> GetByIdAsync(Guid id)
        {
            return await _attachmentRepo.FindAsync(id);
        }

        public async Task<Attachment> CreateAsync(Attachment request)
        {
            request.Id = Guid.NewGuid();
			request.CreatedDate = DateTime.Now;
			var create = await _attachmentRepo.AddAsync(request);
            await _unitOfWork.SaveAsync();
            return create;
        }

        public async Task<Attachment> UpdateAsync(Attachment request)
        {
            var position = await _attachmentRepo.FindAsync(request.Id);
            if (position != null)
            {
				TypeHelper.NormalMapping(request, position, "Id", "CreatedDate", "CreatedBy");
                var update = await _attachmentRepo.UpdateAsync(position);
                await _unitOfWork.SaveAsync();
                return update;
            }

            return null;
        }

        public async Task<Attachment> DeleteAsync(Guid id)
        {
            var position = await _attachmentRepo.FindAsync(id);
            if (position != null)
            {
                await _attachmentRepo.DeleteAsync(position);
                await _unitOfWork.SaveAsync();
                return position ;
            }
            return null;
        }

        public async Task<List<Attachment>> CreateManyAsync(List<Attachment> request)
        {
            foreach (var attachment in request)
            {
                attachment.Id = Guid.NewGuid();
            }
            await _attachmentRepo.AddRangeAsync(request);
            await _unitOfWork.SaveAsync();
            return request;
        }

		public async Task<bool> IsFileInUseAsync(string fileUrl, Guid currentAttachmentId)
		{
            var attachments = await _attachmentRepo.GetByExpression(a => a.Url == fileUrl && a.Id != currentAttachmentId).ToListAsync();
			return attachments.Any();
		}
	}
}
