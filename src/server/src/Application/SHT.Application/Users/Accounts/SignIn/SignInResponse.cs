using SHT.Application.Core;

namespace SHT.Application.Users.Accounts.SignIn
{
    [ApiDataContract]
    public class SignInResponse
    {
        public bool Succeeded { get; set; }
    }
}