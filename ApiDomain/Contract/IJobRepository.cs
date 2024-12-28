using ApiDomain.Entity;
using CommonHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDomain.Contract
{
	public interface IJobRepository
	{
		Task<List<Job>> GetPaggination(PaginationModel request);
		Task<List<Job>> GetAll();
		Task<Job> FindByIdAsync(Guid id);
		Task<Job> InsertAsync(Job job);
		Task<Job> UpdateAsync(Job job);
		Task<Job> DeleteAsync(Guid id);
	}
}
