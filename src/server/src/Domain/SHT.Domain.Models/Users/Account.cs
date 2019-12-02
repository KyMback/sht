namespace SHT.Domain.Models.Users
{
    public class Account : BaseEntity
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public UserType UserType { get; set; }
    }
}