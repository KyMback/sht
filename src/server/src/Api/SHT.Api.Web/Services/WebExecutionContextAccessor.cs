using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using SHT.Infrastructure.Common;

namespace SHT.Api.Web.Services
{
    internal class WebExecutionContextAccessor : IExecutionContextAccessor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public WebExecutionContextAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid GetCurrentUserId()
        {
            var userId = _httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(c =>
                c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;

            return string.IsNullOrEmpty(userId) ? default : Guid.Parse(userId);
        }
    }
}