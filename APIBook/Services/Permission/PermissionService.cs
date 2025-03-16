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

namespace Api.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly ICacheService _cacheService;
        private readonly IUnitOfWork _unitOfWork;
       // private readonly IAuthService _authService;
        private readonly IPermissionRepository _permissionRepository;
        private readonly IMapper _mapper;
        public PermissionService(ICacheService cacheService, IUnitOfWork unitOfWork,  IPermissionRepository permissionRepository, IMapper mapper)
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
        public async Task<bool> InitRole(List<PermissionDto> permission)
        {
            var listPermission = await _permissionRepository.GetAllPermission();
            var listRequest=_mapper.Map<List<Permission>>(permission);
            var notList = listRequest.Where(n => !listPermission.Any(m => m.Code == n.Code));
            if (notList.Any()) {
                notList = notList.Select(n => new Permission
                {
                    Id = n.Id,
                    Name = n.Name,
                    CreatedDate = DateTime.Now,
                    Status = n.Status,
                    Code=n.Code,
                });
                await _unitOfWork.GetRepository<Permission>().AddRangeAsync(notList);
                await _unitOfWork.SaveAsync();
            } 
            return true;
		}

		public async Task<List<PermissionDto>> GetPermissions()
		{
			return _mapper.Map<List<PermissionDto>>(await _permissionRepository.GetAllPermission());

		}
	}
}
