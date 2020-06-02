using System;
using System.Linq;
using CsvHelper.Configuration;

namespace SHT.Infrastructure.Services.Csv
{
    public static class CsvExtensions
    {
        public static MemberMap<TClass, TEnum> Enum<TClass, TEnum>(
            this MemberMap<TClass, TEnum> memberMap)
            where TEnum : struct, Enum
        {
            return memberMap.ConvertUsing(
                row => System.Enum.Parse<TEnum>(
                    row.GetField(memberMap.Data.Names.Single()),
                    true));
        }
    }
}
