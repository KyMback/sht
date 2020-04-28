using SHT.Application.Common;
using SHT.Application.Users.Accounts.Contracts;

namespace SHT.Application.Users.Accounts.ConfirmEmail
{
    public class ConfirmEmailRequest : BaseRequest<ConfirmEmailDataDto>
    {
        public ConfirmEmailRequest(ConfirmEmailDataDto data)
            : base(data)
        {
        }
    }
}