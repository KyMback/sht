using SHT.Application.Common;

namespace SHT.Application.Users.Accounts.Contracts
{
    [ApiDataContract]
    public class SignInDataDto
    {
        public string Login { get; set; }

        public string Password { get; set; }
    }
}