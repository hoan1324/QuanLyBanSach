using ApiDomain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDomain.Entity
{
	public class ActionLog : Entity<Guid>
	{
		public required string Title { get; set; }
		public string? Description { get; set; }
		public string? CreatedBy { get; set; }
		public DateTime? CreatedDate { get; set; }



	}
}
