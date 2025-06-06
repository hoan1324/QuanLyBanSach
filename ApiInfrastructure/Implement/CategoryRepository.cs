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
	public class CategoryRepository : ICategoryRepository
	{
		private readonly IRepository<Category> _categoryRepo;
		private readonly IUnitOfWork _unitOfWork;

		public CategoryRepository(IRepository<Category> categoryRepo, IUnitOfWork unitOfWork)
		{
			_categoryRepo = categoryRepo;
			_unitOfWork = unitOfWork;
		}

		
		public async Task<Category> DeleteAsync(Guid id)
		{
			var position=await _categoryRepo.FindAsync(id);
			if (position == null)
			{
				return null;
			}
			
			
			await _categoryRepo.DeleteAsync(position);
			await _unitOfWork.SaveAsync();
			return position;

		}

		public async Task<Category> FindByIdAsync(Guid id)
		{
			return await _categoryRepo.FindAsync(id);
		}

		public async Task<List<Category>> GetAll()
		{
			return await _categoryRepo.GetAll().AsNoTracking().ToListAsync();
		}
		
		public async Task<PaginationModel<Category>> GetPaggination(PaginationRequestModel request)
		{
			return await PaginatedList<Category>.CreatePaginatedList(_categoryRepo.GetAll(),request);
		}

		public async Task<Category> CreateAsync(Category request)
		{
			var position = await _categoryRepo.FindAsync(request.Id);
			if(position == null)
			{
				var create = await _categoryRepo.AddAsync(request);
				await _unitOfWork.SaveAsync();
				return create;
			}
			return null;
		}

		public async Task<Category> UpdateAsync(Category request)
		{
			var position = await _categoryRepo.FindAsync(request.Id);
			if (position != null)
			{
				//_unitOfWork.GetDbContext().Entry(position).State = EntityState.Detached;
                TypeHelper.NormalMapping(request, position, "Id", "CreatedDate", "CreatedBy");
                var update =await _categoryRepo.UpdateAsync(position);
				await _unitOfWork.SaveAsync();
				return update;
			}
			return null;
		}
	}
}
