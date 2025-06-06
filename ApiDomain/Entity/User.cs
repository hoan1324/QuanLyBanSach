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
		public  string UserName { get; set; }
		public  string Password { get; set; }
		public  string? Address { get; set; }
		public  DateTime DateOfBirth { get; set; }
		public Guid? CreateBy { get; set; }
		public DateTime? CreateDate { get; set; }
		public Guid? ModifiedBy { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public string? FullName {  get; set; }
		public  string PhoneNumber { get; set; }
		public  string Email { get; set; }
		public string? Avatar {  get; set; }
		public  int Gender {  get; set; }
		public int Status {  get; set; } //0:hoatj dong,//1:bij ban
		public Guid RoleID { get; set; }
		public virtual Role? Role { get; set; }
		public ICollection<UserToken>? UserTokens { get; set; }
		public ICollection<UserPermission>? UserPermissions { get; set; }
		public ICollection<BookRating>? BookRatings { get; set; }
		public ICollection<ShoppingCart>? ShoppingCarts { get;set; }
		public ICollection<Comment>? Comments { get; set; }

    }
}
