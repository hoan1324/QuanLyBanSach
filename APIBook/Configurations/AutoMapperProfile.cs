using Api.Dtos;
using APIBook.Dtos;
using APIBook.Dtos.Permission;
using ApiDomain.Entity;
using AutoMapper;
using CommonHelper.Models;
using Newtonsoft.Json;


namespace APIBook.Configurations
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<FilterRequest, PaginationRequestModel>()
				.ForMember(n => n.Filters,
					m => m.MapFrom(h => JsonConvert.DeserializeObject<List<PaginationFilterModel>>(h.Filters)));

			CreateMap<CurrentUserDto, User>()
			 .ForMember(n => n.Password, g => g.Ignore())
			 .ForMember(n => n.UserTokens, g => g.Ignore())
			 .ForMember(n => n.Role, g => g.Ignore())
			 .ForMember(n => n.BookRatings, g => g.Ignore())
			 .ForMember(n => n.ShoppingCarts, g => g.Ignore())
			 .ForMember(n => n.Comments, g => g.Ignore());


			CreateMap<JobDto, Job>()
				.ForMember(n => n.Staffs, m => m.Ignore())
				.ReverseMap();
			CreateMap<Job, JobViewDto>()
			   .ForMember(dest => dest.CreatedByUserName, opt => opt.Ignore())
			   .ForMember(dest => dest.ModifiedByUserName, opt => opt.Ignore());


            CreateMap<CategoryDto, Category>().ReverseMap();
            
			CreateMap<Category, CategoryViewDto>()
               .ForMember(dest => dest.CreatedByUserName, opt => opt.Ignore())
               .ForMember(dest => dest.ModifiedByUserName, opt => opt.Ignore());

            CreateMap<StaffDto, Staff>()
				.ForMember(n => n.Job, m => m.Ignore())
				.ReverseMap();
            
			CreateMap<Staff, StaffViewDto>()
			   .ForMember(dest => dest.CreatedByUserName, opt => opt.Ignore())
			   .ForMember(dest => dest.ModifiedByUserName, opt => opt.Ignore())
			   .ForMember(dest => dest.JobName, opt => opt.Ignore());





            CreateMap<AttachmentDto, Attachment>()
			 .ForMember(n => n.AttachmentFolder, g => g.Ignore())
			 .ReverseMap();

			CreateMap<AttachmentFolderDto, AttachmentFolder>()
				.ForMember(n => n.Attachments, g => g.Ignore())
				.ReverseMap();
			CreateMap<User, CurrentUserDto>()
			   .ForMember(n => n.IsAdmin, g => g.MapFrom(h => h.Role.IsAdmin));

			
			
			CreateMap<UserViewDto, User>()
			   .ForMember(n => n.Password ,g => g.Ignore())
			   .ForMember(n => n.UserTokens, g => g.Ignore())
			   .ForMember(n => n.Role, g => g.MapFrom(n => n.Role))
			   .ForMember(n => n.UserPermissions, g => g.MapFrom(n => n.UserPermissions))
			   .ForMember(n => n.BookRatings, g => g.Ignore())
			   .ForMember(n => n.ShoppingCarts, g => g.Ignore())
			   .ForMember(n => n.Comments, g => g.Ignore())
		       .ReverseMap();

			CreateMap<UserCreateDto, User>()
			  .ForMember(n => n.UserTokens, g => g.Ignore())
			  .ForMember(n => n.Role, g => g.Ignore())
			  .ForMember(n => n.Password, g => g.Ignore())
			  .ForMember(n=>n.UserPermissions,g=>g.Ignore())
              .ForMember(n => n.BookRatings, g => g.Ignore())
			  .ForMember(n => n.ShoppingCarts, g => g.Ignore())
			  .ForMember(n => n.Comments, g => g.Ignore())
			  .ReverseMap();

			CreateMap<RoleDto, Role>()
				.ForMember(n => n.Permissions, g => g.Ignore())
				.ForMember(n => n.Users, g => g.Ignore())
				.ReverseMap();
			
			CreateMap<UserPermissionViewDto, UserPermission>()
				.ForMember(n => n.User, g => g.Ignore())
				.ForMember(n => n.Permission, g => g.Ignore())
				.ReverseMap();

			CreateMap<PermissionDto, Permission>()
				.ForMember(n => n.UserPermissions, g => g.Ignore())
				.ForMember(n => n.PermissionRoles, g => g.Ignore())
				.ReverseMap();

			CreateMap<GroupPermissionDto,GroupPermission>().ReverseMap();
            CreateMap(typeof(PaginationModel<>), typeof(PaginationModel<>));

		}
	}
}
