using Api.Dtos;
using AutoMapper;
using Azure;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq;
using System.Net.WebSockets;
using Api.Domain.Contracts;
using Azure.Core;
using ApiDomain.Entity;
using ApiDomain.Contract;
using ApiDomain.Base;
using APIBook.Services;
using APIBook.Dtos;
using APIBook.Dtos.Permission;
using CommonHelper.Enum;

namespace Api.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly ICacheService _cacheService;
        private readonly IUnitOfWork _unitOfWork;
        // private readonly IAuthService _authService;
        private readonly IPermissionRepository _permissionRepository;
        private readonly IMapper _mapper;
        public PermissionService(ICacheService cacheService, IUnitOfWork unitOfWork, IPermissionRepository permissionRepository, IMapper mapper)
        {
            _cacheService = cacheService;
            _unitOfWork = unitOfWork;
            //_authService = authService;
            _permissionRepository = permissionRepository;
            _mapper = mapper;
        }


        public async Task<List<PermissionDto>> GetUserPermissions(Guid userId)
        {
            return _mapper.Map<List<PermissionDto>>(await _permissionRepository.GetUserPermission(userId));
        }

        public async Task<List<PermissionDto>> UpdateUserPermissions(Guid userId, List<PermissionDto> permissions)
        {
            var listPermission = _mapper.Map<List<Permission>>(permissions);
            var data = await _permissionRepository.UpdateUserPermissions(userId, listPermission);
            await _cacheService.LoadUserToCache(userId, true);
            return _mapper.Map<List<PermissionDto>>(data);
        }

        public async Task<List<PermissionDto>> GetRolePermissions(Guid positionId)
        {
            return _mapper.Map<List<PermissionDto>>(await _permissionRepository.GetRolePermission(positionId));
        }

        public async Task<List<PermissionDto>> UpdateRolePermissions(Guid positionId, List<PermissionDto> permissions)
        {
            var listPermission = _mapper.Map<List<Permission>>(permissions);
            return _mapper.Map<List<PermissionDto>>(await _permissionRepository.UpdateRolePermissions(positionId, listPermission));
        }
        public async Task<bool> InitRole(List<PermissionDto> permissionDtos, List<GroupPermissionDto> groupPermissionDtos)
        {
            var dbPermissions = await _permissionRepository.GetAllPermission();
            var dbGroupPermissions = await _permissionRepository.GetGroupPermission();

            var requestPermissions = _mapper.Map<List<Permission>>(permissionDtos);
            var requestGroupPermissions = _mapper.Map<List<GroupPermission>>(groupPermissionDtos);

            var newGroups = requestGroupPermissions
                .Where(req => !dbGroupPermissions.Any(db => db.Code == req.Code))
                .ToList();

            var newPermissions = requestPermissions
                .Where(req => !dbPermissions.Any(db => db.Code == req.Code))
                .ToList();

            var deletedGroups = dbGroupPermissions
                .Where(db => !requestGroupPermissions.Any(req => req.Code == db.Code))
                .ToList();

            var deletedPermissions = dbPermissions
                .Where(db => !requestPermissions.Any(req => req.Code == db.Code))
                .ToList();

            var updatedGroups = requestGroupPermissions
                .Where(req => dbGroupPermissions.Any(db => db.Code == req.Code && db.Name != req.Name))
                .ToList();

            var updatedPermissions = requestPermissions
                .Where(req => dbPermissions.Any(db => db.Code == req.Code && (db.Name != req.Name || db.Method !=req.Method)))
                .ToList();

            //request co ,database k co(create)
            foreach (var group in newGroups)
            {
                group.Id = Guid.NewGuid();
                var groupCode = group.Code;

                var groupRelatedPermissions = newPermissions
                    .Where(p => p.Code.StartsWith(groupCode + "-"))
                    .ToList();

                foreach (var perm in groupRelatedPermissions)
                {
                    perm.Id = Guid.NewGuid();
                    perm.GroupPermissionId = group.Id;
                }
            }

            // Handle orphan permissions (permissions whose group already exists)
            foreach (var perm in newPermissions.Where(p => p.GroupPermissionId == Guid.Empty).ToList())
            {
                var groupCode = perm.Code.Split('-')[0];
                var group = dbGroupPermissions.FirstOrDefault(g => g.Code.Equals(groupCode, StringComparison.OrdinalIgnoreCase));

                if (group != null)
                {
                    perm.Id = Guid.NewGuid();
                    perm.GroupPermissionId = group.Id;
                }
            }

            await _unitOfWork.GetRepository<GroupPermission>().AddRangeAsync(newGroups);
            await _unitOfWork.GetRepository<Permission>().AddRangeAsync(newPermissions);

            //request co ,database  co nhung khac name(update)
            if (updatedGroups.Any())
            {
                var updatedGroupEntities = updatedGroups
                    .Join(dbGroupPermissions, req => req.Code, db => db.Code, (req, db) => new GroupPermission
                    {
                        Id = db.Id,
                        Code = db.Code,
                        Name = req.Name,
                        Status = req.Status,
                        ModifiedDate = DateTime.Now
                    }).ToList();

                await _unitOfWork.GetRepository<GroupPermission>().UpdateRangeAsync(updatedGroupEntities);
            }

            // Update permissions
            if (updatedPermissions.Any())
            {
                var updatedPermissionEntities = updatedPermissions
                    .Join(dbPermissions, req => req.Code, db => db.Code, (req, db) => new Permission
                    {
                        Id = db.Id,
                        Code = db.Code,
                        Name = req.Name,
                        Status = req.Status,
                        Method = req.Method,
                        ModifiedDate = DateTime.Now,
                        GroupPermissionId = db.GroupPermissionId
                    }).ToList();

                await _unitOfWork.GetRepository<Permission>().UpdateRangeAsync(updatedPermissionEntities);
            }

            //request khong co ,database co (delete)
            // Delete removed permissions first
            await _unitOfWork.GetRepository<Permission>().DeleteRangeAsync(deletedPermissions);

            // Delete removed groups
            await _unitOfWork.GetRepository<GroupPermission>().DeleteRangeAsync(deletedGroups);

            await _unitOfWork.SaveAsync();
            return true;
        }

        public async Task<List<PermissionDto>> GetPermissions()
        {
            return _mapper.Map<List<PermissionDto>>(await _permissionRepository.GetAllPermission());

        }

        public async Task<List<GroupPermissionDto>> GetGroupPermission()
        {
            var groupPermissions = await _permissionRepository.GetEagerLoadingPermissions();
            return _mapper.Map<List<GroupPermissionDto>>(groupPermissions);

        }
    }
}
