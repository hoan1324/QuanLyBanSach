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
		Task<List<Staff>> GetPaggination(PaginationModel request);
		Task<List<Staff>> GetAll();
		Task<Staff> FindByIdAsync(Guid id);
		Task<Staff> InsertAsync(Staff staff);
		Task<Staff> UpdateAsync(Staff staff);
		Task<Staff> DeleteAsync(Guid id);
	}
}
