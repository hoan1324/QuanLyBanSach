using APIBook.Dtos;
using ApiDomain.Contract;
using ApiDomain.Entity;
using AutoMapper;
using CommonHelper.Models;

namespace APIBook.Services
{
	public class RoleService : IRoleService
	{
		private readonly IUserRepository _userRepository;
		private readonly IRoleRepository _roleRepository;
		private readonly IMapper _mapper;
		public RoleService(IUserRepository userRepository, IRoleRepository roleRepository, IMapper mapper)
		{
			_userRepository = userRepository;
			_roleRepository = roleRepository;
			_mapper = mapper;
		}

		public async Task<RoleDto> CreateAsync(RoleDto request)
		{
			//var currentUser = await _authService.CurrentUser();
			request.Id = Guid.NewGuid();
			//request.CreatedBy = currentUser.Id;
			var position = _mapper.Map<Role>(request);
			var create = await _roleRepository.CreateAsync(position);
			return _mapper.Map<RoleDto>(create);
		}

		public async Task<RoleDto> DeleteAsync(Guid id)
		{
			await _roleRepository.DeletePermissionAsync(id);
			var position = await _roleRepository.DeleteAsync(id);
			return _mapper.Map<RoleDto>(position);
		}

		public async Task<List<RoleDto>> DropdownAsync()
		{
			var positions = await _roleRepository.GetAll();
			return _mapper.Map<List<Role>, List<RoleDto>>(positions);
		}

		public async Task<List<RoleDto>> GetAllAsync()
		{
			return _mapper.Map<List<RoleDto>>(await _roleRepository.GetAll());

		}

		public async Task<RoleDto> GetByCodeAsync(string code)
		{

			var position = await _roleRepository.FindByCodeAsync(code);
			if (position == null) return null;
			return _mapper.Map<RoleDto>(position);
		}

		public async Task<RoleDto> GetByIdAsync(Guid id)
		{
			var position = await _roleRepository.FindByIdAsync(id);
			if (position == null) return null;
			return _mapper.Map<RoleDto>(position);
		}

		public async Task<PaginationModel<RoleDto>> GetListAsync(FilterRequest request)
		{
			var req = _mapper.Map<PaginationRequestModel>(request);
			var Role = await _roleRepository.GetPaggination(req);
			return _mapper.Map<PaginationModel<RoleDto>>(Role);
		}

		public async Task<RoleDto> UpdateAsync(RoleDto request)
		{
			//var currentUser = await _authService.CurrentUser();
			var position = await _roleRepository.FindByIdAsync(request.Id);
			if (position == null) return null;

			var positionMapped = _mapper.Map<RoleDto, Role>(request, position);
			//positionMapped.ModifiedBy = currentUser.Id;
			//positionMapped = DateTime.Now;
			await _roleRepository.UpdateAsync(positionMapped);
			return _mapper.Map<RoleDto>(positionMapped);
		}
	}
}
