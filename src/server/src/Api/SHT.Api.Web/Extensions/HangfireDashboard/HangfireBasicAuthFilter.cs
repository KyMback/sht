using System;
using System.Net.Http.Headers;
using System.Text;
using Hangfire.Dashboard;
using Microsoft.AspNetCore.Http;
using SHT.Infrastructure.BackgroundProcess;

namespace SHT.Api.Web.Extensions.HangfireDashboard
{
    internal class HangfireBasicAuthFilter : IDashboardAuthorizationFilter
    {
        private readonly HangfireDashboardOptions _options;

        public HangfireBasicAuthFilter(HangfireDashboardOptions options)
        {
            _options = options;
        }

        /// <inheritdoc />
        public bool Authorize(DashboardContext context)
        {
            var httpContext = context.GetHttpContext();
            var token = GetToken(httpContext);
            if (string.IsNullOrWhiteSpace(token))
            {
                SendUnauthorized(httpContext);
                return false;
            }

            return Authenticate(token);
        }

        private string GetToken(HttpContext context)
        {
            string header = context.Request.Headers["Authorization"];
            if (string.IsNullOrWhiteSpace(header))
            {
                return null;
            }

            var value = AuthenticationHeaderValue.Parse(header);
            return value.Scheme == "Basic" ? value.Parameter : null;
        }

        private bool Authenticate(string base64String)
        {
            string token = Encoding.UTF8.GetString(Convert.FromBase64String(base64String));
            string[] parts = token.Split(":");
            if (parts.Length != 2 || string.IsNullOrWhiteSpace(parts[0]) || string.IsNullOrWhiteSpace(parts[1]))
            {
                throw new UnauthorizedAccessException("Invalid token");
            }

            return Authenticate(parts[0], parts[1]);
        }

        private bool Authenticate(string username, string password)
        {
            return _options.Username == username && _options.Password == password;
        }

        private void SendUnauthorized(HttpContext context)
        {
            context.Response.Clear();
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            context.Response.Headers.Append("WWW-Authenticate", $@"Basic realm=""Hangfire""");
        }
    }
}
