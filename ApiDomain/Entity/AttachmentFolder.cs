using ApiDomain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDomain.Entity
{
	public class AttachmentFolder : Entity<Guid>
	{
		public string? Name { get; set; }
		public string? Description { get; set; }
		public Guid? ParentId { get; set; }
		public Guid? CreatedBy { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public Guid? ModifiedBy { get; set; }
		public int Status { get; set; }

		public virtual ICollection<Attachment>? Attachments { get; set; }
	}
}
