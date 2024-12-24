using ApiDomain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDomain.Entity
{
	public class Category : Entity<Guid>
	{
		
		public required string CategoryName { get; set; }
		public string? Description { get; set; }
		
	}
}
