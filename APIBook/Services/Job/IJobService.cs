using APIBook.Dtos;
using CommonHelper.Models;

namespace APIBook.Services
{
	public interface IJobService
	{
		Task<List<JobDto>> GetAllAsync();
		Task<List<JobDto>> GetListAsync(FilterRequest request);
		Task<JobDto> GetByIdAsync(Guid jobId);
		Task<JobDto> CreateAsync(JobDto request);
		Task<JobDto> UpdateAsync(JobDto request);
		Task<JobDto> DeleteAsync(Guid jobId);
	}
}
