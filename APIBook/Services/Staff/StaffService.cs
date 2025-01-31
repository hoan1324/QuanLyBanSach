using APIBook.Dtos;
using ApiDomain.Contract;
using ApiDomain.Entity;
using AutoMapper;
using CommonHelper.Enum;
using CommonHelper.Models;

namespace APIBook.Services
{
	public class StaffService : IStaffService
	{
		private readonly IStaffRepository _staffRepo;
		private readonly IMapper _mapper;
		public StaffService(IStaffRepository staffRepo, IMapper mapper)
		{
			_staffRepo = staffRepo;
			_mapper = mapper;
		}
		public async Task<StaffDto> CreateAsync(StaffDto request)
		{
			request.Id = Guid.NewGuid();
			request.CreatedDate = DateTime.Now;
			var position= _mapper.Map<Staff>(request);
			var insert =await _staffRepo.InsertAsync(position);
			return _mapper.Map<StaffDto>(insert);
		}

		public async Task<StaffDto> DeleteAsync(Guid staffId)
		{
			var delete= await _staffRepo.DeleteAsync(staffId);
		    return _mapper.Map<StaffDto>(delete);
		}

		public async Task<List<StaffDto>> GetAllAsync()
		{
			return _mapper.Map<List<StaffDto>>(await _staffRepo.GetAll());
		}

		public async Task<StaffDto> GetByIdAsync(Guid staffId)
		{
			return _mapper.Map<StaffDto>(await _staffRepo.FindByIdAsync(staffId));
		}

		public async Task<PaginationModel<StaffDto>> GetListAsync(FilterRequest request)
		{
			var req = _mapper.Map<PaginationRequestModel>(request);
			var paggination = await _staffRepo.GetPaggination(req);
			return _mapper.Map<PaginationModel<StaffDto>>(paggination);
		}

		public async Task<StaffDto> UpdateAsync(StaffDto request)
		{

			var position = _mapper.Map<Staff>(request);
			var update=await _staffRepo.UpdateAsync(position);
			return _mapper.Map<StaffDto>(update);
		}
		
	}
}
