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
	public class CategoryService : ICategoryService
	{
		private readonly ICategoryRepository _categoryRepo;
		private readonly IMapper _mapper;
        private readonly IAuthService _authService;
		private readonly IUnitOfWork _unitOfWork;

        public CategoryService(ICategoryRepository categoryRepo, IMapper mapper, IAuthService authService,IUnitOfWork unitOfWork)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
            _authService = authService;
            _unitOfWork = unitOfWork;
        }



        public async Task<CategoryDto> CreateAsync(CategoryDto request)
		{
            var currentUser = await _authService.CurrentUser();
            request.Id = Guid.NewGuid();
            request.CreatedBy = currentUser?.Id;
            request.CreatedDate = DateTime.Now;
            var position= _mapper.Map<Category>(request);
			var create =await _categoryRepo.CreateAsync(position);
			return _mapper.Map<CategoryDto>(create);
		}

		public async Task<CategoryDto> DeleteAsync(Guid CategoryId)
		{
			var delete= await _categoryRepo.DeleteAsync(CategoryId);
		    return _mapper.Map<CategoryDto>(delete);
		}

		public async Task<List<CategoryDto>> GetAllAsync()
		{
			return _mapper.Map<List<CategoryDto>>(await _categoryRepo.GetAll());
		}

		public async Task<CategoryViewDto> GetByIdAsync(Guid CategoryId)
		{
            var query = (_unitOfWork.GetRepository<Category>().GetAll().JoinEntityWithUser(_unitOfWork.GetRepository<User>().GetAll()));
            var result = await (from item in query
                                where EF.Property<Guid>(item.Source, "Id") == CategoryId
                                select new { item }).FirstOrDefaultAsync();
            if (result == null)
            {
                return null;
            }
            var CategoryViewDto = _mapper.Map<CategoryViewDto>(result.item.Source);
            CategoryViewDto.CreatedByUserName = result.item.CreatedBy?.UserName;
            CategoryViewDto.ModifiedByUserName = result.item.ModifiedBy?.UserName;
            return CategoryViewDto;
        }

        public async Task<PaginationModel<CategoryDto>> GetListAsync(FilterRequest request)
		{
			var req=_mapper.Map<PaginationRequestModel>(request);
			var paggination=await _categoryRepo.GetPaggination(req);
			return _mapper.Map<PaginationModel<CategoryDto>>(paggination);
		}

		public async Task<CategoryDto> UpdateAsync(CategoryDto request)
		{
            var currentUser = await _authService.CurrentUser();
            request.ModifiedDate = DateTime.Now;
            request.ModifiedBy = currentUser?.Id;
            var position = _mapper.Map<Category>(request);

			var update=await _categoryRepo.UpdateAsync(position);
			return _mapper.Map<CategoryDto>(update);
		}

		
	}
}
