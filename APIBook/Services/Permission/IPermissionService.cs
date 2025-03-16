
using Api.Dtos;

namespace Api.Services
{
    public interface IPermissionService
    {
		Task<List<PermissionDto>> GetPermissions();
		Task<bool> InitRole(List<PermissionDto> permission);
        Task<List<PermissionDto>> GetUserPermissions(Guid userId);
        Task<List<PermissionDto>> UpdateUserPermissions(Guid userId, List<PermissionDto> permissions);
        Task<List<PermissionDto>> GetRolePermissions(Guid positionId);
        Task<List<PermissionDto>> UpdateRolePermissions(Guid positionId, List<PermissionDto> permissions);
    }
}
