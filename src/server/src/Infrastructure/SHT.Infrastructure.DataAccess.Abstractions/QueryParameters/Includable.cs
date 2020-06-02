using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SHT.Infrastructure.DataAccess.Abstractions.QueryParameters
{
    public class Includable<TEntity> : IIncludable
    {
        public Includable(Expression<Func<TEntity, object>> expression = default)
        {
            Expression = expression;
        }

        public Expression<Func<TEntity, object>> Expression { get; set; }

        public ThenIncludable ThenIncludable { get; set; }

        public ThenIncludable ThenInclude(Expression<Func<object, object>> expression)
        {
            var then = new ThenIncludable(expression);
            ThenIncludable = then;
            return then;
        }
    }
}