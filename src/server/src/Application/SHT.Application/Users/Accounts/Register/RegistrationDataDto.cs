using SHT.Domain.Models.Users;

namespace SHT.Application.Users.Accounts.Register
{
    public class RegistrationDataDto
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public UserType UserType { get; set; }
    }
}