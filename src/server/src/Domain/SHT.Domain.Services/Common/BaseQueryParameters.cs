using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SHT.Common.Extensions;
using SHT.Infrastructure.DataAccess.Abstractions;
using IQueryProvider = SHT.Infrastructure.DataAccess.Abstractions.IQueryProvider;

namespace SHT.Domain.Services.Common
{
    public class BaseQueryParameters<TEntity> : IQueryParameters<TEntity>
        where TEntity : class
    {
        public bool IsReadOnly { get; set; } = true;

        public bool IsUniq { get; set; }

        public PageSettings PagingSettings { get; set; }

        IList<Expression<Func<TEntity, object>>> IQueryParameters<TEntity>.Included { get; set; } =
            new List<Expression<Func<TEntity, object>>>();

        protected IQueryable<TEntity> Queryable { get; private set; }

        public IQueryable<TEntity> ToQuery(IQueryProvider queryProvider)
        {
            Queryable = queryProvider.Queryable<TEntity>();

            AddFilters();
            AddSorting();

            return Queryable;
        }

        protected void FilterIfHasValue<TValue>(TValue? value, Expression<Func<TEntity, bool>> predicate)
            where TValue : struct
        {
            FilterIf(value.HasValue, predicate);
        }

        protected void FilterIfHasValue(string value, Expression<Func<TEntity, bool>> predicate)
        {
            FilterIf(!string.IsNullOrEmpty(value), predicate);
        }

        protected void FilterIfHasValue<TValue>(IEnumerable<TValue> values, Expression<Func<TEntity, bool>> predicate)
        {
            FilterIf(!values.IsNullOrEmpty(), predicate);
        }

        protected void FilterIf(bool condition, Expression<Func<TEntity, bool>> predicate)
        {
            if (condition)
            {
                Filter(predicate);
            }
        }

        protected void Filter(Expression<Func<TEntity, bool>> predicate)
        {
            Queryable = Queryable.Where(predicate);
        }

        protected void SortAscIf<TKey>(bool predicate, Expression<Func<TEntity, TKey>> keySelector)
        {
            if (predicate)
            {
                Queryable = Queryable.OrderBy(keySelector);
            }
        }

        protected void SortDescIf<TKey>(bool predicate, Expression<Func<TEntity, TKey>> keySelector)
        {
            if (predicate)
            {
                Queryable = Queryable.OrderByDescending(keySelector);
            }
        }

        protected void IncludeIf(bool predicate, Expression<Func<TEntity, object>> expression)
        {
            if (predicate)
            {
                ((IQueryParameters<TEntity>)this).Included.Add(expression);
            }
        }

        protected virtual void AddFilters()
        {
        }

        protected virtual void AddSorting()
        {
        }

        protected virtual void AddIncluded()
        {
        }
    }
}