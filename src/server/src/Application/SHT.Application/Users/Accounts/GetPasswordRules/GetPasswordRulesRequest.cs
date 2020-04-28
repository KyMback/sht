using MediatR;

namespace SHT.Application.Users.Accounts.GetPasswordRules
{
    public class GetPasswordRulesRequest : IRequest<PasswordRulesDto>
    {
    }
}