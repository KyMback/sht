using MediatR;

namespace SHT.Application.Users.Accounts.SignIn
{
    public class SignInDataRequest : IRequest<SignInResponse>
    {
        public string Login { get; set; }

        public string Password { get; set; }
    }
}