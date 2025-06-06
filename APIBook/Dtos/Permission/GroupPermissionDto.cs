using Api.Dtos;
using CommonHelper.Enum;

namespace APIBook.Dtos.Permission
{
    public class GroupPermissionDto
    {
        public Guid Id { get; set; } 
        public string Name { get; set; }
        public string Code { get; set; }
        public int Status { get; set; } //0:hoatj dong,//1 ban
        public DateTime? CreatedDate { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? ModifiedBy { get; set; }
        public List<PermissionDto> Permissions { get; set; } = new List<PermissionDto>();
    }
}
