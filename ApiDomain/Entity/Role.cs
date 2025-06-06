using ApiDomain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDomain.Entity
{
	public class Role : Entity<Guid>
	{
		public  string Name { get; set; }
		public string Code {  get; set; }
		public string? Description { get; set; }
		public DateTime? CreateDate { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? ModifiedBy { get; set; }
        public bool IsAdmin {  get; set; }
		public ICollection<User>? Users { get; set; }
		public ICollection<PermissionRole>? Permissions { get; set; }
	}
}
