using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDomain.Entity
{
	public class Shipping
	{
		public Guid OrderID { get; set; }
		public decimal ShoppingCost {  get; set; }
		public int Status {  get; set; }
		public string? Carrier {  get; set; }
		public DateTime? CreatedDate { get; set; }

		public Order? Order { get; set; }
	}
}
