using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MediatR;
using SHT.Domain.Services.Users;

namespace SHT.Application.Users.Accounts.SignIn
{
    [UsedImplicitly]
    internal class SignInHandler : IRequestHandler<SignInDataRequest, SignInResponse>
    {
        private readonly IAuthenticationService _authenticationService;

        public SignInHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<SignInResponse> Handle(SignInDataRequest request, CancellationToken cancellationToken)
        {
            var result = await _authenticationService.SignIn(new LoginData
            {
                Login = request.Login,
                Password = request.Password,
            });

            return new SignInResponse
            {
                Succeeded = result,
            };
        }
    }
}