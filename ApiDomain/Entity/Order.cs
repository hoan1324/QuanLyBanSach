using ApiDomain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDomain.Entity
{
	public class Order:Entity<Guid>
	{
		public Guid ClientID { get; set; }
		public decimal TotalAmount {  get; set; }
		public virtual Client? Client { get; set; }
		public ICollection<OrderDetail>? Details { get; set; }
		public ICollection<Shipping>? Shippings { get; set; }
	}
}
