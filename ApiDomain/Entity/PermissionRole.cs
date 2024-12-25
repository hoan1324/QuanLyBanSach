using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDomain.Entity
{
	public class PermissionRole
	{
		public Guid PermissionID {  get; set; }
		public Guid RoleID { get; set; }
		public virtual Permission? Permission { get; set; }
		public virtual Role? Role { get; set; }
	}
}
