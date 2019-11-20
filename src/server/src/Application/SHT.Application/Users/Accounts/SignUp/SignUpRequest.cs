using SHT.Application.Core;

namespace SHT.Application.Users.Accounts.SignUp
{
    public class SignUpRequest : BaseRequest<SignUpDataDto>
    {
        public SignUpRequest(SignUpDataDto data)
            : base(data)
        {
        }
    }
}