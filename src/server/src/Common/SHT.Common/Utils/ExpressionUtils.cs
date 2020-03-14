using System;
using System.Linq.Expressions;
using LinqKit;

namespace SHT.Common.Utils
{
    public static class ExpressionUtils
    {
        public static Expression<Func<TSource, TTarget>> Expand<TSource, TTarget>(
            Expression<Func<TSource, TTarget>> expression)
        {
            return expression.Expand();
        }
    }
}