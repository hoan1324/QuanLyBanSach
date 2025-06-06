using APIBook.Dtos;
using CommonHelper.Models;

namespace APIBook.Services
{
	public interface IJobService
	{
		Task<List<JobDto>> GetAllAsync();
		Task<PaginationModel<JobDto>> GetListAsync(FilterRequest request);
		Task<JobViewDto> GetByIdAsync(Guid id);
		Task<JobDto> CreateAsync(JobDto request);
		Task<JobDto> UpdateAsync(JobDto request);
		Task<JobDto> DeleteAsync(Guid id);
	}
}
