using ApiDomain.Entity;
using CommonHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDomain.Contract
{
	public interface ICategoryRepository
	{
		Task<PaginationModel<Category>> GetPaggination(PaginationRequestModel request);
		Task<List<Category>> GetAll();
		Task<Category> FindByIdAsync(Guid id);
		Task<Category> CreateAsync(Category request);
		Task<Category> UpdateAsync(Category request);
		Task<Category> DeleteAsync(Guid id);
	}
}
