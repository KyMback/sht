using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using SHT.Api.Web.Security.Constants;
using SHT.Domain.Models.Users;

namespace SHT.Api.Web.Security
{
    internal class CustomUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<Account>
    {
        public CustomUserClaimsPrincipalFactory(
            UserManager<Account> userManager,
            IOptions<IdentityOptions> optionsAccessor)
            : base(userManager, optionsAccessor)
        {
        }

        public override async Task<ClaimsPrincipal> CreateAsync(Account account)
        {
            var identity = await GenerateClaimsAsync(account);

            identity.AddClaims(new[]
            {
                new Claim(CustomClaimTypes.UserType, account.UserType.ToString("G")),
            });

            return new ClaimsPrincipal(identity);
        }
    }
}