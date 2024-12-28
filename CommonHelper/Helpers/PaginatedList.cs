using CommonHelper.Constant;
using CommonHelper.Models;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CommonHelper.Helpers
{
	public class PaginatedList<T>
	{

		public static async Task<List<T>> CreatePaginatedList(IQueryable<T> source, PaginationModel request)
		{
			if (source == null || source.Count() <= 0) return new List<T>();

			if (!string.IsNullOrEmpty(request.OrderByColumn))
			{
				source = LinQ.Sorting(source, request.OrderByType, request.OrderByColumn);
			}

			var items = source.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize).ToList();
			return items;

		}


	}
}
