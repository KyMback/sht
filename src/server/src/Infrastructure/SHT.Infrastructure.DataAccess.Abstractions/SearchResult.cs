using System.Collections.Generic;

namespace SHT.Infrastructure.DataAccess.Abstractions
{
    public class SearchResult<TData>
    {
        public SearchResult(IReadOnlyCollection<TData> items, long total)
        {
            Items = items;
            Total = total;
        }

        public IReadOnlyCollection<TData> Items { get; set; }

        public long Total { get; set; }
    }
}