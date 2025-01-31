using CommonHelper.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonHelper.Models
{
	public class FilterRequest
	{
		public string? OrderByColumn { get; set; }
		public string? OrderByType { get; set; } = OrderMode.ASC;
		public string? Filters { get; set; }
		public int PageIndex { get; set; } = 1;
		public int PageSize { get; set; } = 20;
	}

	public class PaginationFilterModel
	{
		public required List<string> FilterFields { get; set; }
		public object? Value { get; set; }
		public required string Condition { get; set; }
		public required string FilterType { get; set; }
	}
}
