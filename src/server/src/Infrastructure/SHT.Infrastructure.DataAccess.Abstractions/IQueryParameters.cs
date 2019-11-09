using System.Linq;

namespace SHT.Infrastructure.DataAccess.Abstractions
{
    public interface IQueryParameters<out TEntity>
        where TEntity : class
    {
        bool IsReadOnly { get; set; }

        IQueryable<TEntity> ToQuery(IQueryProvider queryProvider);
    }
}