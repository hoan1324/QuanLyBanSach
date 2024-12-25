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
		public int Status { get; set; }//0:hoatj ddoong,//1 ban
		public ICollection<PermissionRole>? PermissionRoles { get; set; }
		public ICollection<UserPermission>? UserPermissions { get; set; }	
	}
}
