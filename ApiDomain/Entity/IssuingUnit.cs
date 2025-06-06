using ApiDomain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDomain.Entity
{
	public class IssuingUnit : Entity<Guid>
	{
		public required string Name { get; set; }
		public  DateTime StartDate { get; set; }
		public DateTime? EndDate { get; set; }
		public required string Address {  get; set; }
		public required string PhoneNumber { get; set; }
		public required string Email { get; set; }
		public DateTime? CreatedDate { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? ModifiedBy { get; set; }
        public int Status {  get; set; }//0 đang xử lý,//1hop tac,//2 ngung hop tac
		public ICollection<Purchase>? Purchases { get; set; }
		public ICollection<Book>? Books { get; set; }

	}
}
