using MediatR;
using SHT.Application.Users.Accounts.Contracts;

namespace SHT.Application.Users.Accounts.GetPasswordRules
{
    public class GetPasswordRulesRequest : IRequest<PasswordRulesDto>
    {
    }
}