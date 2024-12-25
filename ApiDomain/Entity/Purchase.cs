using ApiDomain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDomain.Entity
{
	public class Purchase:Entity<Guid>
	{
		public Guid IssuingUnitID { get; set; }
		public decimal TotalAmount {  get; set; }
		public virtual IssuingUnit? IssuingUnit { get; set; }
		public ICollection<PurchaseDetail>? PurchaseDetails { get; set; }
	}
}
