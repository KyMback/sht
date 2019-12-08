using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SHT.Infrastructure.DataAccess.Abstractions;
using IQueryProvider = SHT.Infrastructure.DataAccess.Abstractions.IQueryProvider;

namespace SHT.Infrastructure.DataAccess.EF
{
    public static class QueryParametersApplier
    {
        public static IQueryable<TEntity> ApplyQueryParameters<TEntity>(
            IQueryProvider queryProvider,
            IQueryParameters<TEntity> queryParameters)
            where TEntity : class
        {
            var queryable = ApplyCommonQueryParameters(queryProvider, queryParameters);

            if (queryParameters.IsUniq)
            {
                queryable = queryable.Distinct();
            }

            return queryable;
        }

        public static IQueryable<TData> ApplyQueryParameters<TEntity, TData>(
            IQueryProvider queryProvider,
            IQueryParameters<TEntity> queryParameters,
            Expression<Func<TEntity, TData>> selector)
            where TEntity : class
        {
            var queryable = ApplyCommonQueryParameters(queryProvider, queryParameters).Select(selector);

            if (queryParameters.IsUniq)
            {
                queryable = queryable.Distinct();
            }

            return queryable;
        }

        private static IQueryable<TEntity> ApplyCommonQueryParameters<TEntity>(
            IQueryProvider queryProvider,
            IQueryParameters<TEntity> queryParameters)
            where TEntity : class
        {
            var queryable = queryParameters.ToQuery(queryProvider);
            foreach (var expression in queryParameters.Included)
            {
                queryable = queryable.Include(expression);
            }

            if (queryParameters.IsReadOnly)
            {
                queryable = queryable.AsNoTracking();
            }

            return queryable;
        }
    }
}