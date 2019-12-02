using SHT.Application.Common;

namespace SHT.Application.Users.Accounts.SignIn
{
    public class SignInRequest : BaseRequest<SignInDataDto, SignInResponse>
    {
        public SignInRequest(SignInDataDto data)
            : base(data)
        {
        }
    }
}