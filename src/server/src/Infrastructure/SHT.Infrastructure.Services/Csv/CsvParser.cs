using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;

namespace SHT.Infrastructure.Services.Csv
{
    public static class CsvParser
    {
        public static IReadOnlyCollection<TData> Parse<TData>(Func<Stream> streamAccessor, Type classMap)
        {
            using Stream stream = streamAccessor();
            return ParseInternal<TData>(stream, classMap);
        }

        public static async Task<IReadOnlyCollection<TData>> Parse<TData>(
            Func<Task<Stream>> streamAccessor,
            Type classMap)
        {
            using Stream stream = await streamAccessor();
            return ParseInternal<TData>(stream, classMap);
        }

        private static IReadOnlyCollection<TData> ParseInternal<TData>(Stream stream, Type classMap)
        {
            using var reader = new StreamReader(stream);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            csv.Configuration.RegisterClassMap(classMap);

            return csv.GetRecords<TData>().ToArray();
        }
    }
}
