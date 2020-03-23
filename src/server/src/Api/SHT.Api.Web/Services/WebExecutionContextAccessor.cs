using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using SHT.Infrastructure.Common;

namespace SHT.Api.Web.Services
{
    internal class WebExecutionContextAccessor : IExecutionContextAccessor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly Lazy<Guid> _lazyUserId;

        public WebExecutionContextAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _lazyUserId = new Lazy<Guid>(GetUserIdInternally);
        }

        public Guid GetCurrentUserId() => _lazyUserId.Value;

        private Guid GetUserIdInternally()
        {
            var id = GetClaim(ClaimTypes.NameIdentifier);
            return string.IsNullOrEmpty(id) ? default : Guid.Parse(id);
        }

        private string GetClaim(string claimType)
        {
            return _httpContextAccessor.HttpContext.User.Claims
                .SingleOrDefault(c => c.Type == claimType)?.Value;
        }
    }
}