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

		public static async Task<PaginationModel<T>> CreatePaginatedList<T>(IQueryable<T> source, PaginationRequestModel request)
		{
			if (source == null || !source.Any()) return new PaginationModel<T>();

			try
			{
				var countSource = source.Count();
				if (request.Filters?.Any() == true)
				{
					source = LinQ.Where(source, request.Filters);
				}

				if (!string.IsNullOrEmpty(request.OrderByColumn) && !string.IsNullOrEmpty(request.OrderByType))
				{
					source = LinQ.OrderBy(source, request.OrderByColumn,request.OrderByType);
				}

				var items = await Task.Run(() => source
					.Skip((request.PageIndex - 1) * request.PageSize)
					.Take(request.PageSize)
					.ToList());

				return new PaginationModel<T>
				{
					Data = items,
					TotalRow =countSource
				};
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
				return new PaginationModel<T>();
			}

		}
	}
}
