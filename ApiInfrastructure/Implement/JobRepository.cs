using ApiDomain.Base;
using ApiDomain.Contract;
using ApiDomain.Entity;
using ApiInfrastructure.Base;
using Azure.Core;
using CommonHelper.Helpers;
using CommonHelper.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ApiInfrastructure.Implement
{
	public class JobRepository : IJobRepository
	{
		private readonly IRepository<Job> _jobRepo;
		private readonly IUnitOfWork _unitOfWork;

		public JobRepository(IRepository<Job> jobRepo, IUnitOfWork unitOfWork)
		{
			_jobRepo = jobRepo;
			_unitOfWork = unitOfWork;
		}

		
		public async Task<Job> DeleteAsync(Guid id)
		{
			var position=await _jobRepo.FindAsync(id);
			if (position == null)
			{
				return null;
			}
			
			
			await _jobRepo.DeleteAsync(position);
			await _unitOfWork.SaveAsync();
			return position;

		}

		public async Task<Job> FindByIdAsync(Guid id)
		{
			return await _jobRepo.FindAsync(id);
		}

		public async Task<List<Job>> GetAll()
		{
			return await _jobRepo.GetAll().AsNoTracking().ToListAsync();
		}
		
		public async Task<PaginationModel<Job>> GetPaggination(PaginationRequestModel request)
		{
			return await PaginatedList<Job>.CreatePaginatedList(_jobRepo.GetAll(),request);
		}

		public async Task<Job> CreateAsync(Job request)
		{
			var position = await _jobRepo.FindAsync(request.Id);
			if(position == null)
			{
				var create = await _jobRepo.AddAsync(request);
				await _unitOfWork.SaveAsync();
				return create;
			}
			return null;
		}

		public async Task<Job> UpdateAsync(Job request)
		{
			var position = await _jobRepo.FindAsync(request.Id);
			if (position != null)
			{
				//_unitOfWork.GetDbContext().Entry(position).State = EntityState.Detached;
                TypeHelper.NormalMapping(request, position, "Id", "CreatedDate", "CreatedBy");
                var update =await _jobRepo.UpdateAsync(position);
				await _unitOfWork.SaveAsync();
				return update;
			}
			return null;
		}
	}
}
