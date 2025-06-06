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
	public class StaffRepository : IStaffRepository
	{
		private readonly IRepository<Staff> _staffRepo;
		private readonly IUnitOfWork _unitOfWork;

		public StaffRepository(IRepository<Staff> staffRepo, IUnitOfWork unitOfWork)
		{
			_staffRepo = staffRepo;
			_unitOfWork = unitOfWork;
			
		}

		public async Task<Staff> DeleteAsync(Guid id)
		{
			var position=await _staffRepo.FindAsync(id);
			if (position == null) {
				return null;
			}
			await _staffRepo.DeleteAsync(position);
			await _unitOfWork.SaveAsync();
			return position;

		}

		public async Task<Staff> FindByIdAsync(Guid id)
		{
			return await _staffRepo.FindAsync(id);
		}

		public async Task<List<Staff>> GetAll()
		{
			return await _staffRepo.GetAll().AsNoTracking().ToListAsync();
		}

		public async Task<PaginationModel<Staff>> GetPaggination(PaginationRequestModel request)
			
		{
			return await PaginatedList<Staff>.CreatePaginatedList(_staffRepo.GetAll(),request);
		}

		public async Task<Staff> CreateAsync(Staff request)
		{
			var position = await _staffRepo.FindAsync(request.Id);
			if(position == null)
			{
				var create=await _staffRepo.AddAsync(request);
				await _unitOfWork.SaveAsync();
				return create;
			}
			return null;
		}

		public async Task<Staff> UpdateAsync(Staff request)
		{
			var position = await _staffRepo.FindAsync(request.Id);
			if (position != null)
			{
                TypeHelper.NormalMapping(request, position, "Id", "CreatedDate", "CreatedBy");
				var update= await _staffRepo.UpdateAsync(position);
                await _unitOfWork.SaveAsync();
				return update;
			}
			return null;
		}
	}
}
