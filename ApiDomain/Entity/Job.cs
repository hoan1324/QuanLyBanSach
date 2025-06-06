using ApiDomain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDomain.Entity
{
	public class Job : Entity<Guid>
	{
		
		public required string Name { get; set; }
		public string? Description { get; set; }
		public  decimal SalaryMax { get; set; }
		public  decimal SalaryMin { get; set; }
		public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? ModifiedBy { get; set; }
        public Guid? CreatedBy { get; set; }

        public ICollection<Staff>? Staffs { get; set; }
	}
}
