namespace SHT.Api.Web.Security.Options
{
    public class PasswordOptions
    {
        public bool RequireLowercase { get; set; }

        public bool RequireUppercase { get; set; }

        public bool RequireNonAlphanumeric { get; set; }

        public int RequiredLength { get; set; }
    }
}