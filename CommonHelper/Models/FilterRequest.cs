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
        public List<FilterCondition>? Filters { get; set; }
		public string? FilterType {  get; set; }=QueryCondition.OR;
		public int PageIndex { get; set; } = 1;
		public int PageSize { get; set; } = 20;
	}
}
