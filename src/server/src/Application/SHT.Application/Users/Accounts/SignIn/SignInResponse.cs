using SHT.Application.Common;

namespace SHT.Application.Users.Accounts.SignIn
{
    [ApiDataContract]
    public class SignInResponse
    {
        public bool Succeeded { get; set; }
    }
}