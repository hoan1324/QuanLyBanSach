using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDomain.Entity
{
	public class Shipping
	{
		public decimal ShoppingCost {  get; set; }
		public int Status {  get; set; }
		public string? Carrier {  get; set; }
	}
}
