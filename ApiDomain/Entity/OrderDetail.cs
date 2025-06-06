using ApiDomain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDomain.Entity
{
	public class OrderDetail
	{
		public Guid OrderID { get; set; }
		public Guid BookID { get; set; }
		public decimal UnitPrice {  get; set; }
		public int Quantity {  get; set; }
		public decimal NetPrice {  get; set; }

		public Order? Order { get; set; }
		public virtual Book? Book { get; set; }
	}
}
