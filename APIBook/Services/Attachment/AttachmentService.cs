using Api.Domain.Contracts;
using APIBook.Dtos;
using AutoMapper;
using CommonHelper.Models;


namespace Api.Services
{
    public class AttachmentService : IAttachmentService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        //private readonly IAuthService _authService;
        private readonly IAttachmentRepository _attachmentRepository;
        private readonly IMapper _mapper;
        public AttachmentService(IHttpContextAccessor httpContextAccessor,  IAttachmentRepository attachmentRepository, IMapper mapper)
        {
            _httpContextAccessor = httpContextAccessor;
            _attachmentRepository = attachmentRepository;
            _mapper = mapper;
        }
        //public async Task<List<AttachmentDto>> GetMyFiles()
        //{
        //   // var currentUser = await _authService.CurrentUser();
        //    var attachments = await _attachmentRepository.GetByUser(currentUser.Id.Value);
        //    return _mapper.Map<List<Domain.Entities.Attachment>, List<AttachmentDto>>(attachments);
        //}

        public async Task<PaginationModel<AttachmentDto>> GetListAsync(FilterRequest request)
        {
            var req = _mapper.Map<PaginationRequestModel>(request);
            var userPosition = await _attachmentRepository.GetPaggination(req);
            return _mapper.Map<PaginationModel<AttachmentDto>>(userPosition);
        }

        public async Task<AttachmentDto> GetByIdAsync(Guid attachmentId)
        {
            var attachment = await _attachmentRepository.GetByIdAsync(attachmentId);
            if (attachment != null)
            {
                return _mapper.Map<ApiDomain.Entity.Attachment, AttachmentDto>(attachment);
            }
            return null;
        }

        public async Task<AttachmentDto> CreateAsync(AttachmentDto request)
        {
           // var currentUser = await _authService.CurrentUser();
            //request.CreatedBy = currentUser.Id;
            var attachment = _mapper.Map<AttachmentDto, ApiDomain.Entity.Attachment>(request);
            return _mapper.Map<ApiDomain.Entity.Attachment, AttachmentDto>(
                await _attachmentRepository.CreateAsync(attachment));
        }

        public async Task<AttachmentDto> UpdateAsync(AttachmentDto request)
        {
            var attachment = _mapper.Map<AttachmentDto, ApiDomain.Entity.Attachment>(request);
            return _mapper.Map< ApiDomain.Entity.Attachment, AttachmentDto>(
                await _attachmentRepository.UpdateAsync(attachment));
        }

        public async Task<AttachmentDto> DeleteAsync(Guid attachmentId)
        {
            return _mapper.Map< ApiDomain.Entity.Attachment, AttachmentDto>(
                await _attachmentRepository.DeleteAsync(attachmentId));
        }

        public async Task<List<AttachmentDto>> CreateManyAsync(List<AttachmentDto> request)
        {
            var attachments = _mapper.Map<List<AttachmentDto>, List<ApiDomain.Entity.Attachment>>(request);
            return _mapper.Map<List<ApiDomain.Entity.Attachment>, List<AttachmentDto>>(
                await _attachmentRepository.CreateManyAsync(attachments));
        }
    }
}
