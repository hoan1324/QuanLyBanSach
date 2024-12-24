using ApiDomain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDomain.Entity
{
	public class User : Entity<Guid>
	{
		public required string UserName { get; set; }
		public required string Password { get; set; }
		public  DateTime DateOfBirth { get; set; }
		public string? CreateBy { get; set; }
		public DateTime? CreateDate { get; set; }
		public string? ModifiedBy { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public required string PhoneNumber { get; set; }
		public required string Email { get; set; }
		public string? Avatar {  get; set; }
		public required string Gender {  get; set; }
		public int Status {  get; set; }
	   

	}
}
