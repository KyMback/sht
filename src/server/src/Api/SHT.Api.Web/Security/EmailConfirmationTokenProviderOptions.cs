using Microsoft.AspNetCore.Identity;
using SHT.Api.Web.Security.Constants;

namespace SHT.Api.Web.Security
{
    public class EmailConfirmationTokenProviderOptions : DataProtectionTokenProviderOptions
    {
        public EmailConfirmationTokenProviderOptions()
        {
            Name = TokensDefaults.ConfirmEmail.Name;
            TokenLifespan = TokensDefaults.ConfirmEmail.TokenLifespan;
        }
    }
}