using Api.Dtos;
using ApiDomain.Entity;

namespace APIBook.Dtos
{
	public class UserViewDto
	{
		public Guid? Id { get; set; }
		public string? UserName { get; set; }
		public string? Address { get; set; }
		public DateTime DateOfBirth { get; set; }
		public Guid? CreateBy { get; set; }
		public DateTime? CreateDate { get; set; }
		public Guid? ModifiedBy { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public string? FullName { get; set; }
		public string? PhoneNumber { get; set; }
		public string? Email { get; set; }
		public string? Avatar { get; set; }
		public int Gender { get; set; }
		public int Status { get; set; } //0:hoatj dong,//1:bij ban
		public Guid RoleID { get; set; }
		public virtual RoleDto? Role { get; set; }
		public List<UserPermissionViewDto>? UserPermissions { get; set; }
	}
}
