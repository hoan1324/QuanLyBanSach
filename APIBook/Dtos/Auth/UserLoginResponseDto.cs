namespace APIBook.Dtos
{
	public class UserLoginResponseDto
	{
		public Guid? Id { get; set; }
		public string? UserName { get; set; }
		public string? Avatar { get; set; }
		//public bool? IsAdministrator { get; set; }
		public string? AccessToken { get; set; }
		public string? RefreshToken { get; set; }
	}
}
