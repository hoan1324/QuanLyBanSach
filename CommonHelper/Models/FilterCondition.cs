using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonHelper.Models
{
	public class FilterCondition
	{
		public string? Field { get; set; }  // Tên trường cần lọc
		public string? Operator { get; set; }  // Toán tử so sánh (e.g., "=", ">", "<", "LIKE")
		public object? Value { get; set; }  // Giá trị so sánh
	}
}
