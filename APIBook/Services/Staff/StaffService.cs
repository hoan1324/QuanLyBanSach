using APIBook.Dtos;
using ApiDomain.Base;
using ApiDomain.Contract;
using ApiDomain.Entity;
using AutoMapper;
using CommonHelper.Enum;
using CommonHelper.Helpers;
using CommonHelper.Models;
using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.EntityFrameworkCore;

namespace APIBook.Services
{
	public class StaffService : IStaffService
	{
		private readonly IStaffRepository _staffRepo;
		private readonly IMapper _mapper;
		private readonly IAuthService _authService;
		private readonly IUnitOfWork _unitOfWork;
        public StaffService(IStaffRepository staffRepo, IMapper mapper,IAuthService authService,IUnitOfWork unitOfWork)
		{
			_staffRepo = staffRepo;
			_mapper = mapper;
            _authService = authService;
            _unitOfWork = unitOfWork;
        }
		public async Task<StaffDto> CreateAsync(StaffDto request)
		{
			var currentUser = await _authService.CurrentUser();
            request.Id = Guid.NewGuid();
			request.CreatedBy = currentUser?.Id;
            request.CreatedDate = DateTime.Now;
			var position= _mapper.Map<Staff>(request);
			var create =await _staffRepo.CreateAsync(position);
			return _mapper.Map<StaffDto>(create);
		}

		public async Task<StaffDto> DeleteAsync(Guid id)
		{
			var delete= await _staffRepo.DeleteAsync(id);
		    return _mapper.Map<StaffDto>(delete);
		}

		public async Task<List<StaffDto>> GetAllAsync()
		{
			return _mapper.Map<List<StaffDto>>(await _staffRepo.GetAll());
		}

        public async Task<StaffViewDto> GetByIdAsync(Guid id)
        {
            var query = ( _unitOfWork.GetRepository<Staff>().GetAll().JoinEntityWithUser(_unitOfWork.GetRepository<User>().GetAll()));
            var result = await (from item in query
                                join j in _unitOfWork.GetRepository<Job>().GetAll()
                                   on EF.Property<Guid>(item.Source, "JobID") equals j.Id into sj
                                from j in sj.DefaultIfEmpty()
                                where EF.Property<Guid>(item.Source, "Id") == id
                                select new { item, j }).FirstOrDefaultAsync();

			if (result == null)
			{
				return null;
			}
            var staffViewDto = _mapper.Map<StaffViewDto>(result.item.Source);
            staffViewDto.JobName = result.j?.Name ?? string.Empty;
            staffViewDto.CreatedByUserName = result.item.CreatedBy?.UserName;
            staffViewDto.ModifiedByUserName = result.item.ModifiedBy?.UserName;
            return staffViewDto;
        }

        public async Task<PaginationModel<StaffDto>> GetListAsync(FilterRequest request)
		{
			var req = _mapper.Map<PaginationRequestModel>(request);
			var paggination = await _staffRepo.GetPaggination(req);
			return _mapper.Map<PaginationModel<StaffDto>>(paggination);
		}

		public async Task<StaffDto> UpdateAsync(StaffDto request)
		{
            var currentUser = await _authService.CurrentUser();
            request.ModifiedDate = DateTime.Now;
			request.ModifiedBy = currentUser?.Id;
            var position = _mapper.Map<Staff>(request);
			var update=await _staffRepo.UpdateAsync(position);
			return _mapper.Map<StaffDto>(update);
		}
		
	}
}
