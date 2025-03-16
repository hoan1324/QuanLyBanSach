using ApiDomain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDomain.Entity
{
	public class Menu :Entity<Guid>
	{
		public required string Name {  get; set; }
		public string? Target { get; set; }//Định nghĩa mục tiêu khi người dùng nhấn vào menu. Ví dụ:_self: Mở trong tab hiện tại._blank: Mở trong tab mới.
		public string? Url { get; set; }
		public Guid CreateBy { get; set; }
		public DateTime? CreateDate { get; set; }
		public Guid? ModifiedBy { get; set; }
		public DateTime? ModifiedDate { get; set; }
        public Guid ParentID { get; set; }
		public int? Priority {  get; set; }
		public int Status {  get; set; } //0:đang xử lý,1:hoạt động,2:ngừng hoạt động
		
		public ICollection<Book>? Books { get; set; }

	}
}
