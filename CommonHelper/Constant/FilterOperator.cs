using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonHelper.Constant
{
	public class FilterOperator
	{
		public required string Operator { get; set; }
		public required string Method { get; set; }

		public static List<FilterOperator> ListOperator => new List<FilterOperator>
		{
			new FilterOperator { Operator = "==", Method = "Equals" },
			new FilterOperator { Operator = ">", Method = "GreaterThan" },
			new FilterOperator { Operator = "<", Method = "LessThan" },
			new FilterOperator { Operator = ">=", Method = "GreaterThanOrEqual" },
			new FilterOperator { Operator = "<=", Method = "LessThanOrEqual" },
			new FilterOperator { Operator = "contain", Method = "Contains" },

		};
	}
}
