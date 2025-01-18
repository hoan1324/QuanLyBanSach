using APIBook.Dtos;
using ApiDomain.Contract;
using ApiDomain.Entity;
using AutoMapper;
using CommonHelper.Models;

namespace APIBook.Services
{
	public class JobService : IJobService
	{
		private readonly IJobRepository _jobRepo;
		private readonly IMapper _mapper;
		public JobService(IJobRepository jobRepo, IMapper mapper)
		{
			_jobRepo = jobRepo;
			_mapper = mapper;
		}

		public async Task<int> CountAsync()
		{
			return await _jobRepo.Count();
		}

		public async Task<JobDto> CreateAsync(JobDto request)
		{
			request.Id = Guid.NewGuid();
			var position= _mapper.Map<Job>(request);
			var insert =await _jobRepo.InsertAsync(position);
			return _mapper.Map<JobDto>(insert);
		}

		public async Task<JobDto> DeleteAsync(Guid jobId)
		{
			var delete= await _jobRepo.DeleteAsync(jobId);
		    return _mapper.Map<JobDto>(delete);
		}

		public async Task<List<JobDto>> GetAllAsync()
		{
			return _mapper.Map<List<JobDto>>(await _jobRepo.GetAll());
		}

		public async Task<JobDto> GetByIdAsync(Guid jobId)
		{
			return _mapper.Map<JobDto>(await _jobRepo.FindByIdAsync(jobId));
		}

		public async Task<List<JobDto>> GetListAsync(FilterRequest request)
		{
			var req=_mapper.Map<PaginationModel>(request);
			var paggination=await _jobRepo.GetPaggination(req);
			return _mapper.Map<List<JobDto>>(paggination);
		}

		public async Task<JobDto> UpdateAsync(JobDto request)
		{

			var position = _mapper.Map<Job>(request);
			var update=await _jobRepo.UpdateAsync(position);
			return _mapper.Map<JobDto>(update);
		}
	}
}
