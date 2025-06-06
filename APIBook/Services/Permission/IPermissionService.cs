
using Api.Dtos;
using APIBook.Dtos.Permission;
using ApiDomain.Entity;

namespace Api.Services
{
    public interface IPermissionService
    {
		Task<List<PermissionDto>> GetPermissions();
		Task<List<GroupPermissionDto>> GetGroupPermission();
		Task<bool> InitRole(List<PermissionDto> permission,List<GroupPermissionDto> groupPermissions);
        Task<List<PermissionDto>> GetUserPermissions(Guid userId);
        Task<List<PermissionDto>> UpdateUserPermissions(Guid userId, List<PermissionDto> permissions);
        Task<List<PermissionDto>> GetRolePermissions(Guid positionId);
        Task<List<PermissionDto>> UpdateRolePermissions(Guid positionId, List<PermissionDto> permissions);
    }
}
