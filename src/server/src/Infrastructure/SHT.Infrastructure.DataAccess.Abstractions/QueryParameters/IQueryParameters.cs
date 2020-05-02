using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SHT.Infrastructure.DataAccess.Abstractions.QueryParameters
{
    public interface IQueryParameters<TEntity>
        where TEntity : class
    {
        bool IsReadOnly { get; set; }

        bool IsUniq { get; set; }

        PageSettings PagingSettings { get; set; }

        IList<Expression<Func<TEntity, object>>> Included { get; set; }

        IList<Expression<Func<TEntity, bool>>> Filters { get; set; }

        IList<SortOptions<TEntity>> Sorts { get; set; }

        void ApplyRules();
    }
}