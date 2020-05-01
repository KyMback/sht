using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MediatR;
using SHT.Domain.Users;

namespace SHT.Application.Users.Accounts.SignOut
{
    [UsedImplicitly]
    internal class SignOutHandler : IRequestHandler<SignOutRequest>
    {
        private readonly IAuthenticationService _authenticationService;

        public SignOutHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<Unit> Handle(SignOutRequest request, CancellationToken cancellationToken)
        {
            await _authenticationService.SignOut();
            return default;
        }
    }
}