using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SHT.Common.Extensions;
using SHT.Infrastructure.DataAccess.Abstractions;
using SHT.Infrastructure.DataAccess.Abstractions.QueryParameters;

namespace SHT.Domain.Common.Core
{
    public class BaseQueryParameters<TEntity> : IQueryParameters<TEntity>
        where TEntity : class
    {
        public bool IsReadOnly { get; set; } = true;

        public bool IsUniq { get; set; }

        public PageSettings PagingSettings { get; set; }

        IList<Expression<Func<TEntity, object>>> IQueryParameters<TEntity>.Included { get; set; } =
            new List<Expression<Func<TEntity, object>>>();

        IList<Expression<Func<TEntity, bool>>> IQueryParameters<TEntity>.Filters { get; set; } =
            new List<Expression<Func<TEntity, bool>>>();

        IList<SortOptions<TEntity>> IQueryParameters<TEntity>.Sorts { get; set; } = new List<SortOptions<TEntity>>();

        private IQueryParameters<TEntity> QueryParameters => this;

        public void ApplyRules()
        {
            QueryParameters.Filters.Clear();
            QueryParameters.Sorts.Clear();
            QueryParameters.Included.Clear();
            AddFilters();
            AddSorting();
            AddIncluded();
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
            QueryParameters.Filters.Add(predicate);
        }

        protected void SortAscIf(bool predicate, Expression<Func<TEntity, object>> keySelector)
        {
            if (predicate)
            {
                QueryParameters.Sorts.Add(new SortOptions<TEntity>(SortType.Ascending, keySelector));
            }
        }

        protected void SortDescIf(bool predicate, Expression<Func<TEntity, object>> keySelector)
        {
            if (predicate)
            {
                QueryParameters.Sorts.Add(new SortOptions<TEntity>(SortType.Descending, keySelector));
            }
        }

        protected void IncludeIf(bool predicate, Expression<Func<TEntity, object>> expression)
        {
            if (predicate)
            {
                QueryParameters.Included.Add(expression);
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