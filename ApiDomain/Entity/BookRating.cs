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
	    public  Book? Book { get; set; }
		public  User? User { get; set; }
	}
}
