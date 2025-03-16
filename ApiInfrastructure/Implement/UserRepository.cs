using ApiDomain.Base;
using ApiDomain.Contract;
using ApiDomain.Entity;
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
	public class UserRepository : IUserRepository
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IRepository<User> _userRepository;
		private readonly IRepository<UserToken> _userTokenRepository;
		private readonly IRepository<UserPermission> _userPermissionRepository;
		private readonly IRepository<PermissionRole> _permissionRoleRepository;
		private readonly IRepository<Role> _roleRepository;
		public UserRepository(IUnitOfWork unitOfWork, IRepository<User> userRepository, IRepository<UserToken> userTokenRepository, IRepository<UserPermission> userPermissionRepository, IRepository<PermissionRole> PermissionRoleRepository, IRepository<Role> RoleRepository)
		{
			_unitOfWork = unitOfWork;
			_userRepository = userRepository;
			_userTokenRepository = userTokenRepository;
			_userPermissionRepository = userPermissionRepository;
			_permissionRoleRepository = PermissionRoleRepository;
			_roleRepository = RoleRepository;
		}

		public async Task<PaginationModel<User>> GetPaggination(PaginationRequestModel request, bool isAdministrator)
		{

			var query = _userRepository.GetAll().Where(n => isAdministrator || !n.Role.IsAdmin);
			return await PaginatedList<Staff>.CreatePaginatedList(query, request);

		}

		public async Task<bool> IsExistUser(string userName)
		{
			return await _userRepository.GetAll().AsNoTracking().AnyAsync(n => n.UserName == userName);
		}

		public async Task<User> DeleteAsync(Guid id)
		{
			var user = await _userRepository.FindAsync(id);
			if (user != null)
			{
				await _userTokenRepository.DeleteByExpressionAsync(n => n.UserId == id);
				await _userPermissionRepository.DeleteByExpressionAsync(n => n.UserID== id);
				await _userRepository.DeleteByExpressionAsync(n => n.Id == id);
				await _unitOfWork.SaveAsync();
				return user;
			}
			return null;
		}

		public async Task<User?> FindByIdAsync(Guid id)
		{
			return await _userRepository.GetAll()
				.Include(n => n.Role)
				.Include(n => n.UserPermissions)
				.SingleOrDefaultAsync(n => n.Id == id);
		}

		public async Task<User> FindByIdAndRoleAsync(Guid id)
		{
			var user = await _userRepository.GetAll().Include(n => n.Role).FirstOrDefaultAsync(n => n.Id == id);
			return user;
		}

		public async Task<User> FindByUserNameAsync(string userName)
		{
			return await _userRepository.GetAll().AsNoTracking().FirstOrDefaultAsync(n => n.UserName == userName);
		}

		public async Task<User> InsertAsync(User user)
		{
			user.Id = Guid.NewGuid();
			if (await _userRepository.GetAll().AsNoTracking().AnyAsync(n => n.UserName == user.UserName))
				return null;

			var userInserted = await _userRepository.AddAsync(user);
			await _unitOfWork.SaveAsync();
			return userInserted;
		}

		public async Task<User> UpdateAsync(User user)
		{
			var existsUser = await _userRepository.GetAll().Include(n => n.UserPermissions).FirstOrDefaultAsync(n => n.Id == user.Id);
			if (existsUser != null)
			{
				user.Password = existsUser.Password;
				var userUpdated = await _userRepository.UpdateAsync(user);

				await _userPermissionRepository.DeleteByExpressionAsync(n => n.UserID == user.Id);
				var userPermissions = await _permissionRoleRepository
				.GetByExpression(n => n.RoleID == user.RoleID)
				.Select(n => new UserPermission
				{
					UserID = user.Id,
					PermissionCode = n.PermissionCode,
					PermissionID=n.PermissionID
				}).ToListAsync();
				await _userPermissionRepository.AddRangeAsync(userPermissions);
				await _unitOfWork.SaveAsync();
				return userUpdated;
			}
			return null;

		}
		public async Task<bool> UpdatePasswordAsync(Guid id, string newPass)
		{
			var existsUser = await _userRepository.FindAsync(id);
			if (existsUser != null)
			{
				existsUser.Password = newPass;
				var userUpdated = await _userRepository.UpdateAsync(existsUser);
				return await _unitOfWork.SaveAsync() > 0;
			}
			return false;

		}
		public async Task<UserToken> InsertUserTokenAsync(UserToken userToken)
		{
			await _userTokenRepository.AddAsync(userToken);
			await _unitOfWork.SaveAsync();
			return userToken;
		}

		public async Task<UserToken> UpdateUserTokenAsync(UserToken userToken)
		{
			var userUpdated = await _userTokenRepository.UpdateAsync(userToken);
			await _unitOfWork.SaveAsync();
			return userUpdated;
		}

		public async Task<List<UserToken>> DeleteUserTokenAsync(Guid userId)
		{
			var userToken = await _userTokenRepository.GetByExpression(n => n.UserId == userId).ToListAsync();
			await _userTokenRepository.DeleteRangeAsync(userToken);
			await _unitOfWork.SaveAsync();
			return userToken;
		}

		public async Task<UserToken> FindUserTokenById(Guid id)
		{
			return await _userTokenRepository.FindAsync(id);
		}

		public async Task<UserToken?> FindUserTokenByUserId(Guid id)
		{
			return await _userTokenRepository.GetByExpression(n => n.UserId == id).FirstOrDefaultAsync();
		}

		public async Task<List<User>> GetByRole(string code)
		{
			var position = await _roleRepository.GetAll().FirstOrDefaultAsync(n => n.Code == code);
			if (position != null)
			{
				return await _userRepository.GetByExpression(n => n.RoleID == position.Id).Select(n => new User
				{
					Id = n.Id,
					UserName = n.UserName,
					RoleID = n.RoleID,
				}).ToListAsync();
			}
			return null;
		}
	}
}
