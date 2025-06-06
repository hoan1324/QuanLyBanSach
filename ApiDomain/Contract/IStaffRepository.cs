using ApiDomain.Entity;
using CommonHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ApiDomain.Contract
{
	public interface IStaffRepository
	{
		Task<PaginationModel<Staff>> GetPaggination(PaginationRequestModel request);
		Task<List<Staff>> GetAll();
		Task<Staff> FindByIdAsync(Guid id);
		Task<Staff> CreateAsync(Staff request);
		Task<Staff> UpdateAsync(Staff request);
		Task<Staff> DeleteAsync(Guid id);
	}
}
