using SHT.Application.Common;

namespace SHT.Application.Users.Accounts.Contracts
{
    [ApiDataContract]
    public class PasswordRulesDto
    {
        public bool RequireLowercase { get; set; }

        public bool RequireUppercase { get; set; }

        public bool RequireDigit { get; set; }

        public bool RequireNonAlphanumeric { get; set; }

        public int RequiredLength { get; set; }
    }
}