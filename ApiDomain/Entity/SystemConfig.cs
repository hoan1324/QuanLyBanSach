using ApiDomain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDomain.Entity
{
	public class SystemConfig : Entity<Guid>
	{
		public required string Key { get; set; }
		public  string? Value { get; set; }
		public string? Image { get; set; }
		public string? Data { get; set; }
		public string? Url { get; set; }
		public string? Icon { get; set; }
		public int Status { get; set; }
	}
}
