using Microsoft.AspNetCore.Authorization;
using SHT.Api.Web.Security.Constants;

namespace SHT.Api.Web.Attributes
{
    internal class AuthorizeStudentsOnlyAttribute : AuthorizeAttribute
    {
        public AuthorizeStudentsOnlyAttribute()
            : base(AuthorizationPolicyNames.StudentsOnly)
        {
        }
    }
}