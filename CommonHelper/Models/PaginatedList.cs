using CommonHelper.Constant;
using CommonHelper.Helpers;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CommonHelper.Models
{
	public class PaginatedList<T> : List<T>
	{
		public PaginatedList(List<T> items)
		{
			AddRange(items);
		}
		public static async Task<PaginatedList<T>> CreatePaginatedList(IQueryable<T> source, FilterRequest request)
		{
			if (source == null || source.Count() <= 0) return new PaginatedList<T>(new List<T>());

			if (!string.IsNullOrEmpty(request.OrderByColumn))
			{
				source = LinQ.Sorting(source, request.OrderByType, request.OrderByColumn);
			}
			if (request.Filters.Any())
			{
				source = LinQ.FilterExpression(source, request.Filters, request.FilterType);
			}
			var items=source.Skip((request.PageIndex-1)*request.PageSize).Take(request.PageSize).ToList();
			return new PaginatedList<T>(items);

		}


	}
}
