using SHT.Application.Core;

namespace SHT.Application.Users.Accounts.SignIn
{
    [ApiDataContract]
    public class SignInDataDto
    {
        public string Login { get; set; }

        public string Password { get; set; }
    }
}