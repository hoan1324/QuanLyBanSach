using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDomain.Entity
{
	public class Warehouse
	{
		public Guid BookID { get; set; }
		public int InventoryQuantity {  get; set; }
		public  Book? Book { get; set; }
	}
}
