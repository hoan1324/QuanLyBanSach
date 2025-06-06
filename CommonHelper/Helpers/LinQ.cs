using CommonHelper.Constant;
using CommonHelper.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CommonHelper.Helpers
{
    public static class LinQ
    {
        public static IQueryable<T> Where<T>(this IQueryable<T> query, List<PaginationFilterModel> filters)
        {
            var parameters = Expression.Parameter(typeof(T), "n");
            if (filters.Count > 0)
            {
                var filterExpressions = new List<Expression>();
                foreach (var filter in filters)
                {
                    if (filter.FilterFields?.Count > 0)
                    {
                        List<Expression> fieldExpressions = new();
                        foreach (var field in filter.FilterFields)
                        {
                            if (typeof(T).GetProperties().FirstOrDefault(n => n.Name == field) != null)
                            {
                                var type = typeof(T).GetProperties().FirstOrDefault(n => n.Name == field)?.PropertyType;
                                fieldExpressions.Add(GetExpression(parameters, filter, field, type));
                            }
                        }
                        filterExpressions.Add(OrElseExpression(fieldExpressions));
                    }
                }

                if (filterExpressions.Where(n => n != null).Any())
                {
                    var express = AndAlsoExpression(filterExpressions);
                    if (express != null)
                    {
                        var lambda = Expression.Lambda<Func<T, bool>>(express, parameters);
                        return query.Where(lambda);
                    }
                }

                return query;
            }
            return query;
        }
        public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, string propertyName, string orderType)
        {
            var entityType = typeof(T);
            var propertyInfo = entityType.GetProperty(propertyName);
            if (propertyInfo == null)
            {
                throw new ArgumentException($"Property {propertyName} not found on type {entityType.Name}");
            }

            var parameter = Expression.Parameter(entityType, "x");
            var property = Expression.Property(parameter, propertyName);
            var lambda = Expression.Lambda(property, parameter);

            string methodName = orderType.ToLower() == "desc" ? "OrderByDescending" : "OrderBy";
            var orderByExpression = Expression.Call(
                typeof(Queryable),
                methodName,
                new Type[] { entityType, propertyInfo.PropertyType },
                source.Expression,
                lambda
            );

            return source.Provider.CreateQuery<T>(orderByExpression);
        }
        public static IQueryable<EntityWithUser<TSource, TDes>> JoinEntityWithUser<TSource, TDes>(
        this IQueryable<TSource> source, IQueryable<TDes> des)
         where TSource : class
        where TDes : class
        {
            // Chỉ join được nếu property tên đúng và có thể truy cập trực tiếp
            var query = from s in source
                        join createdBy in des on EF.Property<object>(s, "CreatedBy") equals EF.Property<object>(createdBy, "Id") into createdByGroup
                        from createdBy in createdByGroup.DefaultIfEmpty()
                        join modifiedBy in des on EF.Property<object>(s, "ModifiedBy") equals EF.Property<object>(modifiedBy, "Id") into modifiedByGroup
                        from modifiedBy in modifiedByGroup.DefaultIfEmpty()
                        select new EntityWithUser<TSource, TDes>
                        {
                            Source = s,
                            CreatedBy = createdBy,
                            ModifiedBy = modifiedBy
                        };

            return query;
        }

        private static Expression GetExpression(ParameterExpression parameters, PaginationFilterModel filter, string fieldName, Type? type)
        {
            Expression prop = Expression.Property(parameters, fieldName);
            if (filter.Value != null)
            {
                var valueType = filter.Value.GetType();
                if (valueType == typeof(JObject))
                {
                    var reqJson = JObject.Parse(filter.Value.ToString());
                    var from = reqJson["from"] != null && !string.IsNullOrEmpty(reqJson["from"].ToString()) ? DateTime.Parse(reqJson["from"].ToString()).Date : DateTime.Now.Date;
                    var to = reqJson["to"] != null && !string.IsNullOrEmpty(reqJson["to"].ToString()) ? DateTime.Parse(reqJson["to"].ToString()).Date : DateTime.Now.Date;

                    var fromConst = Expression.Constant(from, typeof(DateTime));
                    var toConst = Expression.Constant(to, typeof(DateTime));
                    MemberExpression dateProperty = Expression.Property(prop, "Date");
                    var expressionFrom = Expression.GreaterThanOrEqual(dateProperty, fromConst);
                    var expressionTo = Expression.LessThanOrEqual(dateProperty, toConst);
                    return Expression.AndAlso(expressionFrom, expressionTo);
                }

                var nonNullType = Nullable.GetUnderlyingType(type);
                var propValue = Expression.Constant(filter.Value);
                MethodInfo parseMethod = null;

                if (type == typeof(string) && valueType == typeof(JArray))
                {
                    var values = (filter.Value as JArray).ToObject<List<string>>();
                    MethodInfo containsMethod = typeof(List<string>).GetMethod("Contains", new[] { typeof(string) });

                    // Tạo một biểu thức để kiểm tra xem prop có nằm trong danh sách không
                    var listExpression = Expression.Constant(values); // Danh sách giá trị

                    return Expression.Call(listExpression, containsMethod, prop);
                }


                if (type == typeof(string))
                {
                    MethodInfo method = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                    var containsMethodExp = Expression.Call(prop, method, propValue);
                    return containsMethodExp;
                }
                else if (type == typeof(DateTime) || type == typeof(DateTime?))
                {
                    var date = Convert.ToDateTime(filter.Value);
                    ConstantExpression todayConstant = Expression.Constant(date.Date, typeof(DateTime));
                    MemberExpression dateProperty = Expression.Property(prop, "Date");

                    if (filter.Condition == "==") return Expression.Equal(dateProperty, todayConstant);
                    else if (filter.Condition == "!=") return Expression.NotEqual(dateProperty, todayConstant);
                    else if (filter.Condition == ">") return Expression.GreaterThan(dateProperty, todayConstant);
                    else if (filter.Condition == "<") return Expression.LessThan(dateProperty, todayConstant);
                    else if (filter.Condition == ">=") return Expression.GreaterThanOrEqual(dateProperty, todayConstant);
                    else if (filter.Condition == "<=") return Expression.LessThanOrEqual(dateProperty, todayConstant);

                }
                else
                {
                    if (nonNullType != null) parseMethod = nonNullType.GetMethod("Parse", new[] { typeof(string) });
                    else parseMethod = typeof(Convert).GetMethod("To" + type.Name, new[] { valueType });
                }

                var parseExpression = Expression.Call(parseMethod, propValue);
                var parseToTargetType = Expression.Convert(parseExpression, type);
                Expression equalExpression = null;

                if (filter.Condition == "==") equalExpression = Expression.Equal(prop, parseToTargetType);
                else if (filter.Condition == "!=") equalExpression = Expression.NotEqual(prop, parseToTargetType);
                else if (filter.Condition == ">") equalExpression = Expression.GreaterThan(prop, parseToTargetType);
                else if (filter.Condition == "<") equalExpression = Expression.LessThan(prop, parseToTargetType);
                else if (filter.Condition == ">=") equalExpression = Expression.GreaterThanOrEqual(prop, parseToTargetType);
                else if (filter.Condition == "<=") equalExpression = Expression.LessThanOrEqual(prop, parseToTargetType);

                return equalExpression;
            }
            else return null;

        }
        private static Expression OrElseExpression(List<Expression> expressions)
        {
            if (expressions.Count > 0)
            {
                expressions = expressions.Where(n => n != null).ToList();
                if (expressions.Count == 1) return expressions.First();
                if (expressions.Count > 1)
                {
                    Expression mergeExpression = null;
                    for (int i = 0; i < expressions.Count; i++)
                    {
                        var lastExpression = expressions[i];
                        if (mergeExpression == null) mergeExpression = lastExpression;
                        if ((i + 1) < expressions.Count)
                        {
                            mergeExpression = Expression.OrElse(mergeExpression, expressions[i + 1]);
                        }
                    }
                    return mergeExpression;
                }
            }

            return null;
        }
        private static Expression AndAlsoExpression(List<Expression> expressions)
        {
            if (expressions.Count > 0)
            {
                expressions = expressions.Where(n => n != null).ToList();
                if (expressions.Count == 1) return expressions.First();

                Expression mergeExpression = null;
                for (int i = 0; i < expressions.Count; i++)
                {
                    var lastExpression = expressions[i];
                    if ((i + 1) < expressions.Count)
                    {
                        mergeExpression = Expression.AndAlso(lastExpression, expressions[i + 1]);
                    }
                }
                return mergeExpression;
            }

            return null;
        }

    }
}
