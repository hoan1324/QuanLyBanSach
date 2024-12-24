using ApiDomain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDomain.Entity
{
	public class Permission : Entity<Guid>
	{
		public required string Name { get; set; }
		public required string Code { get; set; }
		public int Status { get; set; }
	}
}
