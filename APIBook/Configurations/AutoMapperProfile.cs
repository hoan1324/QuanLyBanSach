using APIBook.Dtos;
using ApiDomain.Entity;
using AutoMapper;
using CommonHelper.Models;

namespace APIBook.Configurations
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<PaginationModel, FilterRequest>()
				//.ForMember(n => n.Filters, m => m.Ignore())
				//.ForMember(n => n.FilterType, m => m.Ignore())
				.ReverseMap();
			
			CreateMap<JobDto, Job>()
				.ForMember(n => n.Staffs, m => m.Ignore())
				.ReverseMap();

			CreateMap<StaffDto, Staff>()
				.ForMember(n => n.Job, m => m.Ignore())
				.ReverseMap();
		}
	}
}
