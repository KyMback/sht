using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using SHT.Infrastructure.Common;
using SHT.Infrastructure.Common.ExecutionContext;

namespace SHT.Api.Web.Services
{
    internal class WebExecutionContextService : IExecutionContextService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly Lazy<Guid> _lazyUserId;

        public WebExecutionContextService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _lazyUserId = new Lazy<Guid>(GetUserIdInternally);
        }

        public Guid GetCurrentUserId() => _lazyUserId.Value;

        public void SetExecutionContext(IExecutionContext context)
        {
            throw new NotImplementedException();
        }

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