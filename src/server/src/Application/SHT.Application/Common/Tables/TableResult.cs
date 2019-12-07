using System.Collections.Generic;

namespace SHT.Application.Common.Tables
{
    public class TableResult<TData>
    {
        public TableResult(IReadOnlyCollection<TData> items, long total)
        {
            Items = items;
            Total = total;
        }

        public IReadOnlyCollection<TData> Items { get; set; }

        public long Total { get; set; }
    }
}