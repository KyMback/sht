using System;

namespace SHT.Api.Web.Security.Constants
{
    internal static class TokensDefaults
    {
        public static class ConfirmEmail
        {
            public const string Purpose = "EmailConfirmation";

            public const string Name = nameof(ConfirmEmail);

            public static readonly TimeSpan TokenLifespan = TimeSpan.FromDays(1);
        }
    }
}