using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MediatR;
using SHT.Domain.Services.Users;

namespace SHT.Application.Users.Accounts.SignOut
{
    public static class SignOutCommand
    {
        public class Command : IRequest
        {
        }

        [UsedImplicitly]
        internal class Handler : IRequestHandler<Command>
        {
            private readonly IAuthenticationService _authenticationService;

            public Handler(IAuthenticationService authenticationService)
            {
                _authenticationService = authenticationService;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                await _authenticationService.SignOut();
                return Unit.Value;
            }
        }
    }
}