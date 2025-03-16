using System.ComponentModel.DataAnnotations;

namespace APIBook.Dtos
{
	public class LoginRequestDto
	{
		[Required(ErrorMessage = "Tên tài khoản không thể để trống !")]
		public required string UserName { get; set; }

		[Required(ErrorMessage = "Mật không thể để trống !")]
		public required string Password { get; set; }

	}
}
