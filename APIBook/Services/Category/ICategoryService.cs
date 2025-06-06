using APIBook.Dtos;
using CommonHelper.Models;

namespace APIBook.Services
{
	public interface ICategoryService
	{
		Task<List<CategoryDto>> GetAllAsync();
		Task<PaginationModel<CategoryDto>> GetListAsync(FilterRequest request);
		Task<CategoryViewDto> GetByIdAsync(Guid id);
		Task<CategoryDto> CreateAsync(CategoryDto request);
		Task<CategoryDto> UpdateAsync(CategoryDto request);
		Task<CategoryDto> DeleteAsync(Guid id);
	}
}
