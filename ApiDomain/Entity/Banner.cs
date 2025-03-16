using ApiDomain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDomain.Entity
{
	public class Banner :Entity<Guid>
	{
		public required string Name {  get; set; }
		public string? Title { get; set; }
		public string? Summary {  get; set; }
		public string? Url { get; set; }
		public Guid? CreateBy { get; set; }
		public DateTime? CreateDate { get; set; }
		public Guid? ModifiedBy { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public string? Description {  get; set; }
		public required string Media {  get; set; }
		public DateTime AnnouncementTime {  get; set; }//Thoi gian cong bo
		public int Group {  get; set; }//banner o trang chu,trang con
		public int Status {  get; set; } //trann thais banner dang cho,hoat dong,da xoa
		


	}
}
