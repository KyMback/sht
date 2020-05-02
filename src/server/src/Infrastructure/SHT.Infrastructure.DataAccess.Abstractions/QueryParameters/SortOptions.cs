using System;
using System.Linq.Expressions;

namespace SHT.Infrastructure.DataAccess.Abstractions.QueryParameters
{
    public class SortOptions<TEntity>
    {
        public SortOptions(SortType type, Expression<Func<TEntity, object>> sortExpression)
        {
            Type = type;
            SortExpression = sortExpression;
        }

        public SortType Type { get; set; }

        public Expression<Func<TEntity, object>> SortExpression { get; set; }
    }
}