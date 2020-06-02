using System;
using System.Linq.Expressions;

namespace SHT.Infrastructure.DataAccess.Abstractions.QueryParameters
{
    public interface IIncludable
    {
        ThenIncludable ThenInclude(Expression<Func<object, object>> expression);
    }
}