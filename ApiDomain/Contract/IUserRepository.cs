using ApiDomain.Entity;
using CommonHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDomain.Contract
{
	public interface IUserRepository
	{
		Task<PaginationModel<User>> GetPaggination(PaginationRequestModel request, bool isAdministrator);
		Task<bool> IsExistUser(string userName);
		Task<User> FindByUserNameAsync(string userName);
		Task<User?> FindByIdAsync(Guid id);
		Task<User> FindByIdAndRoleAsync(Guid id);
		Task<User> CreateAsync(User request);
		Task<User> UpdateAsync(User request);
		Task<bool> UpdatePasswordAsync(Guid id, string newPass);
		Task<User> DeleteAsync(Guid id);
		Task<List<User>> GetByRole(string code);
	}
}
