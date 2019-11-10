using Microsoft.AspNetCore.Authorization;
using SHT.Api.Web.Security.Constants;

namespace SHT.Api.Web.Attributes
{
    internal class AuthorizeInstructorsOnlyAttribute : AuthorizeAttribute
    {
        public AuthorizeInstructorsOnlyAttribute()
            : base(AuthorizationPolicyNames.InstructorsOnly)
        {
        }
    }
}