using MediatR;
using SHT.Application.Users.Accounts.Contracts;

namespace SHT.Application.Users.Accounts.GetUserContext
{
    public class GetUserContextRequest : IRequest<UserContextDto>
    {
    }
}