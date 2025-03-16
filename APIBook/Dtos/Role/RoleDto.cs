using ApiDomain.Entity;

namespace APIBook.Dtos
{
	public class RoleDto
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Code { get; set; }
		public string? Description { get; set; }
		public DateTime? CreateDate { get; set; }
		public bool IsAdmin { get; set; }
	}
}
