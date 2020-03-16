using System.Linq;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Infrastructure.DataAccess.EF
{
    public static class QueryableExtensions
    {
        public static IQueryable<TData> WithPaging<TData>(this IQueryable<TData> queryable, PageSettings settings)
        {
            if (settings == null)
            {
                return queryable;
            }

            return queryable.Skip((settings.PageNumber - 1) * settings.PageSize).Take(settings.PageSize);
        }
    }
}