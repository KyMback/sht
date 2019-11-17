using SHT.Application.Core;

namespace SHT.Application.Users.Accounts.SignIn
{
    public class SignInRequest : BaseCommand<SignInDataDto, SignInResponse>
    {
        public SignInRequest(SignInDataDto dataDto)
            : base(dataDto)
        {
        }
    }
}