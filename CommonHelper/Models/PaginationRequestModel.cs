using CommonHelper.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonHelper.Models
{
	public class PaginationRequestModel
	{
		public string? OrderByColumn { get; set; }
		public string? OrderByType { get; set; } = OrderMode.ASC;
		public List<PaginationFilterModel>? Filters { get; set; }
		public int PageIndex { get; set; } = 1;
		public int PageSize { get; set; } = 20;
	}
}
