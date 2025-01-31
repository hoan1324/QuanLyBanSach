using ApiDomain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDomain.Entity
{
	public class Attachment : Entity<Guid>
	{
		public string? Name { get; set; }
		public string? Extention { get; set; }
		public string? Url { get; set; }
		public float? Size { get; set; }
		public DateTime CreatedDate { get; set; }
		public Guid? CreatedBy { get; set; }
		public Guid? AttachmentFolderId { get; set; }

		public virtual AttachmentFolder? AttachmentFolder { get; set; }
	}
}
