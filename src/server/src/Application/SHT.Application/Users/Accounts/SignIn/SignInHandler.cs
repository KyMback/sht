using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MediatR;
using SHT.Domain.Services.Users;

namespace SHT.Application.Users.Accounts.SignIn
{
    [UsedImplicitly]
    internal class SignInHandler : IRequestHandler<SignInRequest, SignInResponse>
    {
        private readonly IAuthenticationService _authenticationService;

        public SignInHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<SignInResponse> Handle(SignInRequest request, CancellationToken cancellationToken)
        {
            var result = await _authenticationService.SignIn(new LoginData
            {
                Login = request.Data.Login,
                Password = request.Data.Password,
            });

            return new SignInResponse
            {
                Succeeded = result,
            };
        }
    }
}