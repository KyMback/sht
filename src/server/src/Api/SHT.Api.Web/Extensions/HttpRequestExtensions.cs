using System;
using System.Linq;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using SHT.Api.Web.Constants;

namespace SHT.Api.Web.Extensions
{
    internal static class HttpRequestExtensions
    {
        public static bool IsSpaPageRequest(this HttpRequest request)
        {
            return request.Method == HttpMethods.Get
                   && request.IsAcceptingHtml()
                   && !request.IsApiRequest()
                   && !request.IsSwaggerRequest();
        }

        private static bool IsAcceptingHtml(this HttpRequest request)
        {
            return request.Headers[HeaderNames.Accept].Any(header =>
                header.Contains(MediaTypeNames.Text.Html, StringComparison.InvariantCulture));
        }

        private static bool IsSwaggerRequest(this HttpRequest request)
        {
            return request.Path.StartsWithSegments(RoutesConstants.SwaggerUiRoute, StringComparison.InvariantCultureIgnoreCase)
                   || request.Path.StartsWithSegments(RoutesConstants.SwaggerJsonRoute, StringComparison.InvariantCultureIgnoreCase);
        }

        private static bool IsApiRequest(this HttpRequest request)
        {
            return request.Path.StartsWithSegments(RoutesConstants.Api, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}