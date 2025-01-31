using APIBook.Dtos;
using CommonHelper.Models;

namespace APIBook.Services
{
	public interface IStaffService
	{
		Task<List<StaffDto>> GetAllAsync();
		Task<PaginationModel<StaffDto>> GetListAsync(FilterRequest request);
		Task<StaffDto> GetByIdAsync(Guid staff);
		Task<StaffDto> CreateAsync(StaffDto request);
		Task<StaffDto> UpdateAsync(StaffDto request);
		Task<StaffDto> DeleteAsync(Guid staff);
	}
}
