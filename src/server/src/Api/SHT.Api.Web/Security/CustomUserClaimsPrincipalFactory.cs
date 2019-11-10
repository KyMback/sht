using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using SHT.Api.Web.Security.Constants;
using SHT.Domain.Models.Users;

namespace SHT.Api.Web.Security
{
    internal class CustomUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<User>
    {
        public CustomUserClaimsPrincipalFactory(
            UserManager<User> userManager,
            IOptions<IdentityOptions> optionsAccessor)
            : base(userManager, optionsAccessor)
        {
        }

        public override async Task<ClaimsPrincipal> CreateAsync(User user)
        {
            var identity = await GenerateClaimsAsync(user);

            identity.AddClaims(new[]
            {
                new Claim(CustomClaimTypes.UserType, user.UserType.ToString("G")),
            });

            return new ClaimsPrincipal(identity);
        }
    }
}