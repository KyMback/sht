namespace SHT.Domain.Services.Users
{
    public class PasswordRules
    {
        public bool RequireLowercase { get; set; }

        public bool RequireUppercase { get; set; }

        public bool RequireDigit { get; set; }

        public bool RequireNonAlphanumeric { get; set; }

        public int RequiredLength { get; set; }
    }
}