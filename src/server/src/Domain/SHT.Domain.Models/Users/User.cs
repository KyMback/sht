namespace SHT.Domain.Models.Users
{
    public class User : BaseEntity
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public UserType UserType { get; set; }
    }
}