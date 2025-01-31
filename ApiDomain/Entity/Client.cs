using ApiDomain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDomain.Entity
{
	public class Client :Entity<Guid>
	{
		public required string Name { get; set; }
		public string? Description {  get; set; }
		public required string Address { get; set; }
		public required string PhoneNumber { get; set; }
		public int Gender { get; set; }
		public string? Email {  get; set; }
		public DateTime? DateOfBirth {  get; set; }
		public DateTime? CreateDate { get; set; }
		public Guid? UserID { get; set; }
		public ICollection<Order>? Order { get; set; }

	}
}
