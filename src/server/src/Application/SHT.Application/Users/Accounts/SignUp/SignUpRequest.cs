using SHT.Application.Common;

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