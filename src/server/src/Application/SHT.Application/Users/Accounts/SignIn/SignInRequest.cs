using SHT.Application.Common;
using SHT.Application.Users.Accounts.Contracts;

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