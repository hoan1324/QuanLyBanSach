﻿using APIBook.Dtos;
using CommonHelper.Models;

namespace APIBook.Services
{
	public interface IRoleService
	{
		Task<List<RoleDto>> GetAllAsync();
		Task<PaginationModel<RoleDto>> GetListAsync(FilterRequest request);
		Task<RoleDto> GetByIdAsync(Guid id);
		Task<RoleDto> GetByCodeAsync(string code);
		Task<RoleDto> CreateAsync(RoleDto request);
		Task<RoleDto> UpdateAsync(RoleDto request);
		Task<RoleDto> DeleteAsync(Guid id);
		Task<List<RoleDto>> DropdownAsync();
	}
}
