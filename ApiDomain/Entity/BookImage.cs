using ApiDomain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDomain.Entity
{
	public class BookImage : Entity<Guid>
	{
	    public required string Image {  get; set; }
		public bool? IsDefault { get; set; }
		public Guid BookID { get; set; }
		public Book? Book { get; set; } 
	}
}
