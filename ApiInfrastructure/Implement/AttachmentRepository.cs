using Api.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.Domain.Base;
using Api.Domain.Entities;
using ComonHelpers.Helpers;
using ComonHelpers.Models;
using Microsoft.EntityFrameworkCore;

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
            return await _attachmentRepo.GetAll().Paggination(request);
        }

        public async Task<Attachment?> GetByIdAsync(Guid attachmentId)
        {
            return await _attachmentRepo.FindAsync(attachmentId);
        }

        public async Task<Attachment> CreateAsync(Attachment request)
        {
            request.Id = Guid.NewGuid();
			request.CreatedDate = DateTime.Now;
			var attachment = await _attachmentRepo.AddAsync(request);
            await _unitOfWork.SaveAsync();
            return attachment;
        }

        public async Task<Attachment> UpdateAsync(Attachment request)
        {
            var attachment = await _attachmentRepo.FindAsync(request.Id);
            if (attachment != null)
            {
                TypeHelper.NormalMapping(request, attachment, "Id", "CreatedDate", "CreatedBy");
                var attachmentUpdate = await _attachmentRepo.UpdateAsync(request);
                await _unitOfWork.SaveAsync();
                return attachmentUpdate;
            }

            return null;
        }

        public async Task<Attachment> DeleteAsync(Guid attachmentId)
        {
            var attachment = await _attachmentRepo.FindAsync(attachmentId);
            if (attachment != null)
            {
                await _attachmentRepo.DeleteAsync(attachment);
                await _unitOfWork.SaveAsync();
                return attachment;
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
    }
}
