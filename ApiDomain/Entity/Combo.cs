using ApiDomain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDomain.Entity
{
	public class Combo:Entity<Guid>
	{
		public required string Name {  get; set; }
		public string? Description { get; set; }
		public string? Image { get; set; }
		public DateTime? CreateDate { get; set; }
		public bool? IsActive { get; set; }
		public ICollection<ComboBook>? Books { get; set; }
	}
}
