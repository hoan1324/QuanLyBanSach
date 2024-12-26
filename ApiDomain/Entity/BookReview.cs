using ApiDomain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDomain.Entity
{
	public class BookReview
	{
		public Guid BookID { get; set; }
		public int? salesTotal {  get; set; }
		public decimal? Rate {  get; set; }
		public Book? Book { get; set; }


	}
}
