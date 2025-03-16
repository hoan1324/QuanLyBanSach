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
	public class RoleRepository : IRoleRepository
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IRepository<Role> _roleRepo;
		private readonly IRepository<PermissionRole> _permissionRoleRepo;
		public RoleRepository(IUnitOfWork unitOfWork,IRepository<Role>roleRepo,IRepository<PermissionRole> permissionRoleRepo)
		{
			_unitOfWork = unitOfWork;
			_roleRepo = roleRepo;	
			_permissionRoleRepo = permissionRoleRepo;
		}
		public async Task<Role> DeleteAsync(Guid id)
		{
			var position = await _roleRepo.FindAsync(id);
			await _roleRepo.DeleteAsync(position);
			await _unitOfWork.SaveAsync();
			return position;
		}

		public async Task<List<PermissionRole>> DeletePermissionAsync(Guid id)
		{
			var permission = await _permissionRoleRepo.GetByExpression(n => n.RoleID == id).ToListAsync();
			await _permissionRoleRepo.DeleteRangeAsync(permission);
			await _unitOfWork.SaveAsync();
			return permission;
		}

		public async Task<Role?> FindByCodeAsync(string code)
		{
			return await _roleRepo.GetByExpression(f => f.Code.Contains(code) || f.Code.Equals(code)).FirstOrDefaultAsync();
		}

		public async Task<Role?> FindByIdAsync(Guid id)
		{
			return await _roleRepo.FindAsync(id);
		}

		public async Task<List<Role>> GetAll()
		{
			return await _roleRepo.GetAll().AsNoTracking().ToListAsync();
		}

		public async Task<PaginationModel<Role>> GetPaggination(PaginationRequestModel request)
		{
			return await PaginatedList<Job>.CreatePaginatedList(_roleRepo.GetAll(), request);
		}

		public async Task<Role> InsertAsync(Role role)
		{
			role.Id = Guid.NewGuid();
			await _roleRepo.AddAsync(role);
			await _unitOfWork.SaveAsync();
			return role;
		}

		public async Task<Role> UpdateAsync(Role role)
		{
			var exists = await _roleRepo.FindAsync(role.Id);
			if (exists != null)
			{
				TypeHelper.NormalMapping(role, exists, "Id", "CreatedDate", "CreatedBy");
				var position = await _roleRepo.UpdateAsync(role);
				await _unitOfWork.SaveAsync();
				return position;
			}
			return null;
		}
	}
}
