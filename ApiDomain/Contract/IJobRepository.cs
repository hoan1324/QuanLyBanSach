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
		Task<PaginationModel<Job>> GetPaggination(PaginationRequestModel request);
		Task<List<Job>> GetAll();
		Task<Job> FindByIdAsync(Guid id);
		Task<Job> CreateAsync(Job request);
		Task<Job> UpdateAsync(Job request);
		Task<Job> DeleteAsync(Guid id);
	}
}
