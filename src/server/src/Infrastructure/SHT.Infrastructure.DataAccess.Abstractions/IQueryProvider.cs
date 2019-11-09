using System.Linq;

namespace SHT.Infrastructure.DataAccess.Abstractions
{
    public interface IQueryProvider
    {
        IQueryable<TEntity> Queryable<TEntity>()
            where TEntity : class;
    }
}