using ApiDomain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDomain.Entity
{
	public class QuestionAndAnswer :Entity<Guid>
	{
		public required string Question { get; set; }
		public required string Answer { get; set; }
		public Guid? CreateBy {  get; set; }
		public DateTime? CreateDate { get; set; }
		public Guid? ModifiedBy { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public int Status { get; set; }//0:đang phê duyệt//đã phê duyệt

	}
}
