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
		Task<User> InsertAsync(User user);
		Task<User> UpdateAsync(User user);
		Task<bool> UpdatePasswordAsync(Guid id, string newPass);
		Task<User> DeleteAsync(Guid id);
		Task<UserToken> InsertUserTokenAsync(UserToken userToken);
		Task<UserToken> UpdateUserTokenAsync(UserToken userToken);
		Task<List<UserToken>> DeleteUserTokenAsync(Guid userId);
		Task<UserToken> FindUserTokenById(Guid id);
		Task<UserToken?> FindUserTokenByUserId(Guid id);
		Task<List<User>> GetByRole(string code);
	}
}
