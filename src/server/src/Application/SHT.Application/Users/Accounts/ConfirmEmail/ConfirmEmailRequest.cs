using SHT.Application.Common;

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