using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MediatR;
using SHT.Application.Core;
using SHT.Domain.Services.Users;

namespace SHT.Application.Users.Accounts.SignIn
{
    public static class SignInCommand
    {
        public static BaseCommand<SignInDataDto> Command(SignInDataDto data) => new BaseCommand<SignInDataDto>(data);

        [UsedImplicitly]
        internal class Handler : IRequestHandler<BaseCommand<SignInDataDto>>
        {
            private readonly IAuthenticationService _authenticationService;

            public Handler(IAuthenticationService authenticationService)
            {
                _authenticationService = authenticationService;
            }

            public async Task<Unit> Handle(BaseCommand<SignInDataDto> request, CancellationToken cancellationToken)
            {
                await _authenticationService.SignIn(new LoginData
                {
                    Login = request.Data.Login,
                    Password = request.Data.Password,
                });

                return Unit.Value;
            }
        }
    }
}