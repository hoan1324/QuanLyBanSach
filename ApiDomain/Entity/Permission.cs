using ApiDomain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDomain.Entity
{
	public class Permission : Entity<Guid>
	{
		public  string Name { get; set; }
		public  string Code { get; set; }
		public int Method { get; set; } //1:Create, 2:Read, 3:Update, 4:Delete
        public int Status { get; set; }//0:hoatj ddoong,//1 ban
		public DateTime? CreatedDate { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? ModifiedBy { get; set; }
		public Guid? GroupPermissionId { get; set; }
		public virtual GroupPermission? GroupPermission { get; set; }
        public ICollection<PermissionRole>? PermissionRoles { get; set; }
		public ICollection<UserPermission>? UserPermissions { get; set; }	
	}
}
