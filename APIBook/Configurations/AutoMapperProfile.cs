using APIBook.Dtos;
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

			CreateMap<JobDto, Job>()
				.ForMember(n => n.Staffs, m => m.Ignore())
				.ReverseMap();

			CreateMap<StaffDto, Staff>()
				.ForMember(n => n.Job, m => m.Ignore())
				.ReverseMap();

			CreateMap(typeof(PaginationModel<>), typeof(PaginationModel<>));

			CreateMap<AttachmentDto, Attachment>()
			 .ForMember(n => n.AttachmentFolder, g => g.Ignore())
			 .ReverseMap();

			CreateMap<AttachmentFolderDto, AttachmentFolder>()
				.ForMember(n => n.Attachments, g => g.Ignore())
				.ReverseMap();

		}
	}
}
