using SHT.Application.Core;

namespace SHT.Application.Users.Accounts.SignUp
{
    public class SignUpRequest : BaseCommand<SignUpDataDto>
    {
        public SignUpRequest(SignUpDataDto data)
            : base(data)
        {
        }
    }
}