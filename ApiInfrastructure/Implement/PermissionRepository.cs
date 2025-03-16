using ApiDomain.Base;
using ApiDomain.Contract;
using ApiDomain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiInfrastructure.Implement
{
	public class PermissionRepository : IPermissionRepository
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IRepository<Permission> _permissionRepository;
		private readonly IRepository<UserPermission> _userPermissionRepository;
		private readonly IRepository<PermissionRole> _permissionRoleRepository;
	
		public PermissionRepository(IUnitOfWork unitOfWork, IRepository<Permission> permissionRepository, IRepository<UserPermission> userPermissionRepository, IRepository<PermissionRole> permissionRoleRepository)
		{
			_unitOfWork = unitOfWork;
			_permissionRepository = permissionRepository;
			_userPermissionRepository = userPermissionRepository;
			_permissionRoleRepository = permissionRoleRepository;	
		}
		public async Task<List<Permission>> GetAllPermission()
		{
			return await _permissionRepository.GetAll().AsNoTracking().ToListAsync();
		}

		public async Task<List<Permission>> GetRolePermission(Guid roleId)
		{
			var rolePermissions = _permissionRoleRepository.GetByExpression(n => n.RoleID == roleId).AsNoTracking();
			return await _permissionRepository
				.GetByExpression(n => rolePermissions.Any(m => m.PermissionID == n.Id)).ToListAsync();
		}

		public async Task<List<Permission>> GetUserPermission(Guid userId)
		{
			var userPermissions = _userPermissionRepository.GetByExpression(n => n.UserID == userId).AsNoTracking();
			return await _permissionRepository
				.GetByExpression(n => userPermissions.Any(m => m.PermissionID == n.Id)).ToListAsync();
		}

		public async Task<List<Permission>> UpdateRolePermissions(Guid roleId, List<Permission> permissions)
		{
			await _permissionRoleRepository.DeleteByExpressionAsync(n => n.RoleID == roleId);
			var newPermissions = permissions.Select(n => new PermissionRole
			{
				PermissionCode=n.Code,
				PermissionID = n.Id,
				RoleID = roleId
			});
			await _permissionRoleRepository.AddRangeAsync(newPermissions);
			await _unitOfWork.SaveAsync();
			return permissions;
		}

		public async Task<List<Permission>> UpdateUserPermissions(Guid userId, List<Permission> permissions)
		{
			await _userPermissionRepository.DeleteByExpressionAsync(n => n.UserID == userId);
			var newPermissions = permissions.Select(n => new UserPermission
			{
				PermissionCode = n.Code,
				PermissionID = n.Id,
				UserID = userId
			});
			await _userPermissionRepository.AddRangeAsync(newPermissions);
			await _unitOfWork.SaveAsync();
			return permissions;
		}
	}
}
