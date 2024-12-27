using CommonHelper.Constant;
using CommonHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommonHelper.Helpers
{
	public class LinQ
	{
		public static IQueryable<T> Sorting<T>(IQueryable<T> items, string OrderByType, string OrderByColumn)
		{
			var parameter = Expression.Parameter(typeof(T), "x");
			var property = Expression.Property(parameter, OrderByColumn);
			var lambda = Expression.Lambda(property, parameter);
			string method = OrderByType == OrderMode.ASC ? "OrderBy" : "OrderByDescending";

			var result = Expression.Call(
				 typeof(Queryable), method, new Type[] { typeof(T), property.Type }, items.Expression, lambda);
			return items.Provider.CreateQuery<T>(result);
		}
		public static IQueryable<T> FilterExpression<T>(IQueryable<T> items, List<FilterCondition> Filters, string FilterType)
		{

			var parameter = Expression.Parameter(typeof(T), "x");
			Expression? combinedExpression = null;

			foreach (var filterCondition in Filters)
			{
				var property = Expression.Property(parameter, filterCondition.Field);
				var constant = Expression.Constant(filterCondition.Value);
				var methodCompare = FilterOperator.ListOperator.FirstOrDefault(items => items.Operator == filterCondition.Operator).Method;
				var comparison = Expression.Call(property, typeof(string).GetMethod(methodCompare, new[] { typeof(string) }), constant);
				combinedExpression = combinedExpression == null ? comparison
					: FilterType == QueryCondition.OR
					? Expression.OrElse(combinedExpression, comparison)
					: Expression.AndAlso(combinedExpression, comparison);
			}
			var lambda = Expression.Lambda<Func<T, bool>>(combinedExpression, parameter);
			return items.Where(lambda);
		}
	}
}
