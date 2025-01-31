using ApiDomain.Base;
using ApiDomain.Contract;
using ApiDomain.Entity;
using ApiInfrastructure.Base;
using CommonHelper.Helpers;
using CommonHelper.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

		public async Task<Job> InsertAsync(Job job)
		{
			var position = await _jobRepo.FindAsync(job.Id);
			if(position == null)
			{
				var insertJob=await _jobRepo.AddAsync(job);
				await _unitOfWork.SaveAsync();
				return insertJob;
			}
			return null;
		}

		public async Task<Job> UpdateAsync(Job job)
		{
			var position = await _jobRepo.FindAsync(job.Id);
			if (position != null)
			{
				_unitOfWork.GetDbContext().Entry(position).State = EntityState.Detached;
				var updateJob=await _jobRepo.UpdateAsync(job);
				await _unitOfWork.SaveAsync();
				return updateJob;
			}
			return null;
		}
	}
}
