using System;

namespace SHT.Tests.Integration.Extensions
{
    internal static class StringExtensions
    {
        public static Uri ToRelativeUri(this string path)
        {
            return new Uri(path, UriKind.Relative);
        }
    }
}