using SHT.Domain.Models.Users;

namespace SHT.Application.Users.Accounts.SignUp
{
    public class SignUpDataDto
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public UserType UserType { get; set; }
    }
}