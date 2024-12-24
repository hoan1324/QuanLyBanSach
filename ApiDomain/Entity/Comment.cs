using ApiDomain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDomain.Entity
{
	public class Comment:Entity<Guid>
	{
		public Guid BookID { get; set; }
		public Guid UserID { get; set; }
		public Guid? ParentID { get; set; }
		public required string Detail { get; set; }
		public DateTime? CreateDate { get; set; }
		public virtual User? User { get; set; }
		public virtual Book? Book { get; set; }
	}
}
