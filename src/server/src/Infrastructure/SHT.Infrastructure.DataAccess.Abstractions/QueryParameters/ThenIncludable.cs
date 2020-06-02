using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SHT.Infrastructure.DataAccess.Abstractions.QueryParameters
{
    public class ThenIncludable : IIncludable
    {
        public ThenIncludable(Expression<Func<object, object>> expression = default)
        {
            Expression = expression;
        }

        public Expression<Func<object, object>> Expression { get; set; }

        public ThenIncludable NestedThenIncludable { get; set; }

        public ThenIncludable ThenInclude(Expression<Func<object, object>> expression)
        {
            var then = new ThenIncludable(expression);
            NestedThenIncludable = then;
            return then;
        }
    }
}