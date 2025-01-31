using CommonHelper.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonHelper.Models
{
	public class PaginationModel<T>
	{
		public int TotalRow { get; set; }
		public List<T>? Data { get; set; }
		public PaginationModel()
		{
			TotalRow = 0;
			Data = new List<T>();
		}
	}
}
