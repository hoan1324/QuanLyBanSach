using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDomain.Entity
{
	public class UserPermission
	{
		public Guid UserID { get; set; }
		public Guid PermissionID {  get; set; }
		public virtual Permission? Permission { get; set; }
		public virtual User? User { get; set; }
	}
}
