using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SHT.Infrastructure.DataAccess.Abstractions
{
    public interface IQueryParameters<TEntity>
        where TEntity : class
    {
        bool IsReadOnly { get; set; }

        IList<Expression<Func<TEntity, object>>> Included { get; set; }

        IQueryable<TEntity> ToQuery(IQueryProvider queryProvider);
    }
}