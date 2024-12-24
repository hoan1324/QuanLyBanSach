using ApiDomain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDomain.Entity
{
	public class ShoppingCart 
	{
		
		public Guid UserID { get; set; }
		public Guid BookID { get; set; }
		public string? Code {  get; set; }
		public int Status {  get; set; }
		
	}
}
