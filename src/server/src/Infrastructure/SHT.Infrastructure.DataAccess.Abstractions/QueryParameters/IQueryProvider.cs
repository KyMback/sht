using System.Linq;

namespace SHT.Infrastructure.DataAccess.Abstractions.QueryParameters
{
    public interface IQueryProvider
    {
        IQueryable<TEntity> Queryable<TEntity>()
            where TEntity : class;

        IQueryable<TEntity> Queryable<TEntity>(IQueryParameters<TEntity> queryParameters)
            where TEntity : class;
    }
}