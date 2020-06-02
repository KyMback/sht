using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using SHT.Infrastructure.DataAccess.Abstractions.QueryParameters;

namespace SHT.Infrastructure.DataAccess.EF
{
    public static class QueryParametersApplier
    {
        public static IQueryable<TEntity> ApplyQueryParameters<TEntity>(
            IQueryable<TEntity> queryable,
            IQueryParameters<TEntity> queryParameters)
            where TEntity : class
        {
            queryable = ApplyCommonQueryParameters(queryable, queryParameters);

            if (queryParameters.IsUniq)
            {
                queryable = queryable.Distinct();
            }

            return queryable;
        }

        public static IQueryable<TData> ApplyQueryParameters<TEntity, TData>(
            IQueryable<TEntity> queryable,
            IQueryParameters<TEntity> queryParameters,
            Expression<Func<TEntity, TData>> selector)
            where TEntity : class
        {
            var selectQueryable = ApplyCommonQueryParameters(queryable, queryParameters).Select(selector);

            if (queryParameters.IsUniq)
            {
                selectQueryable = selectQueryable.Distinct();
            }

            return selectQueryable;
        }

        private static IQueryable<TEntity> ApplyCommonQueryParameters<TEntity>(
            IQueryable<TEntity> queryable,
            IQueryParameters<TEntity> queryParameters)
            where TEntity : class
        {
            queryParameters.ApplyRules();

            foreach (var filter in queryParameters.Filters)
            {
                queryable = queryable.Where(filter);
            }

            foreach (var queryParametersSort in queryParameters.Sorts)
            {
                queryable = queryParametersSort.Type == SortType.Ascending
                    ? queryable.OrderBy(queryParametersSort.SortExpression)
                    : queryable.OrderByDescending(queryParametersSort.SortExpression);
            }

            foreach (var expression in queryParameters.Included)
            {
                queryable = queryable.Include(expression);
            }

            foreach (var queryParametersIncludable in queryParameters.Includables)
            {
                queryable = Include(
                    queryable.Include(queryParametersIncludable.Expression),
                    queryParametersIncludable.ThenIncludable);
            }

            if (queryParameters.IsReadOnly)
            {
                queryable = queryable.AsNoTracking();
            }

            return queryable;
        }

        private static IQueryable<TEntity> Include<TEntity>(IIncludableQueryable<TEntity, object> queryable, ThenIncludable includable)
            where TEntity : class
        {
            if (includable == null)
            {
                return queryable;
            }

            queryable = queryable.ThenInclude(includable.Expression);
            return Include(queryable, includable.NestedThenIncludable);
        }
    }
}