using ApiDomain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDomain.Entity
{
	public class BookRating
	{
		public Guid BookID { get; set; }
		public Guid UserID { get; set; }
		public int Rating {  get; set; }
		public DateTime? CreateDate { get; set; }
	    public virtual Book? Book { get; set; }
		public virtual User? User { get; set; }
	}
}
