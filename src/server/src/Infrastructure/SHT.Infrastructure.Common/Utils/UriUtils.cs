using System;
using System.Collections.Specialized;
using System.Web;

namespace SHT.Infrastructure.Common.Utils
{
    public static class UriUtils
    {
        public static string AddQueryArguments(string path, params (string Key, string Value)[] arguments)
        {
            var uriBuilder = new UriBuilder(path);
            NameValueCollection query = HttpUtility.ParseQueryString(uriBuilder.Query);
            foreach (var (key, value) in arguments)
            {
                query.Add(key, value);
            }

            uriBuilder.Query = query.ToString();
            return uriBuilder.ToString();
        }
    }
}