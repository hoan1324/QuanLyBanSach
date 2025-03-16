using ApiDomain.Entity;
using CommonHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDomain.Contract
{
	public interface IRoleRepository
	{
		Task<PaginationModel<Role>> GetPaggination(PaginationRequestModel request);
		Task<List<Role>> GetAll();
		Task<Role?> FindByIdAsync(Guid id);
		Task<Role?> FindByCodeAsync(string code);
		Task<Role> InsertAsync(Role role);
		Task<Role> UpdateAsync(Role role);
		Task<Role> DeleteAsync(Guid id);
		Task<List<PermissionRole>> DeletePermissionAsync(Guid id);
	}
}
