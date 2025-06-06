using APIBook.Dtos;
using ApiDomain.Base;
using ApiDomain.Contract;
using ApiDomain.Entity;
using AutoMapper;
using CommonHelper.Helpers;
using CommonHelper.Models;
using Microsoft.EntityFrameworkCore;

namespace APIBook.Services
{
	public class JobService : IJobService
	{
		private readonly IJobRepository _jobRepo;
		private readonly IMapper _mapper;
        private readonly IAuthService _authService;
		private readonly IUnitOfWork _unitOfWork;

        public JobService(IJobRepository jobRepo, IMapper mapper, IAuthService authService,IUnitOfWork unitOfWork)
        {
            _jobRepo = jobRepo;
            _mapper = mapper;
            _authService = authService;
            _unitOfWork = unitOfWork;
        }



        public async Task<JobDto> CreateAsync(JobDto request)
		{
            var currentUser = await _authService.CurrentUser();
            request.Id = Guid.NewGuid();
            request.CreatedBy = currentUser?.Id;
            request.CreatedDate = DateTime.Now;
            var position= _mapper.Map<Job>(request);
			var create =await _jobRepo.CreateAsync(position);
			return _mapper.Map<JobDto>(create);
		}

		public async Task<JobDto> DeleteAsync(Guid id)
		{
			var delete= await _jobRepo.DeleteAsync(id);
		    return _mapper.Map<JobDto>(delete);
		}

		public async Task<List<JobDto>> GetAllAsync()
		{
			return _mapper.Map<List<JobDto>>(await _jobRepo.GetAll());
		}

		public async Task<JobViewDto> GetByIdAsync(Guid id)
		{
            var query = (_unitOfWork.GetRepository<Job>().GetAll().JoinEntityWithUser(_unitOfWork.GetRepository<User>().GetAll()));
            var result = await (from item in query
                                where EF.Property<Guid>(item.Source, "Id") == id
                                select new { item }).FirstOrDefaultAsync();
            if (result == null)
            {
                return null;
            }
            var jobViewDto = _mapper.Map<JobViewDto>(result.item.Source);
            jobViewDto.CreatedByUserName = result.item.CreatedBy?.UserName;
            jobViewDto.ModifiedByUserName = result.item.ModifiedBy?.UserName;
            return jobViewDto;
        }

        public async Task<PaginationModel<JobDto>> GetListAsync(FilterRequest request)
		{
			var req=_mapper.Map<PaginationRequestModel>(request);
			var paggination=await _jobRepo.GetPaggination(req);
			return _mapper.Map<PaginationModel<JobDto>>(paggination);
		}

		public async Task<JobDto> UpdateAsync(JobDto request)
		{
            var currentUser = await _authService.CurrentUser();
            request.ModifiedDate = DateTime.Now;
            request.ModifiedBy = currentUser?.Id;
            var position = _mapper.Map<Job>(request);

			var update=await _jobRepo.UpdateAsync(position);
			return _mapper.Map<JobDto>(update);
		}

		
	}
}
