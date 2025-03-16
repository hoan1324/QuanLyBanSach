namespace APIBook.Dtos
{
	public class UserChangePasswordDto
	{
		public Guid Id { get; set; }
		public required string UserName { get; set; }
		public required string OldPassword { get; set; }
		public required string NewPassword { get; set; }

	}
	public class ResetPassDto
	{
		public Guid Id { get; set; }
	}
}
