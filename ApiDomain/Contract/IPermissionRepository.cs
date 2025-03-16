using ApiDomain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDomain.Contract
{
	public interface IPermissionRepository
	{
		//Task<List<GroupPermission>> GetPermissions();
		Task<List<Permission>> GetAllPermission();
		Task<List<Permission>> GetUserPermission(Guid userId);
		Task<List<Permission>> GetRolePermission(Guid roleId);
		Task<List<Permission>> UpdateRolePermissions(Guid roleId, List<Permission> permissions);
		Task<List<Permission>> UpdateUserPermissions(Guid userId, List<Permission> permissions);
	}
}
