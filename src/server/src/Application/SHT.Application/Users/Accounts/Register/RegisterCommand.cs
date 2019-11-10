using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MediatR;
using SHT.Application.Core;
using SHT.Domain.Services.Users;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Application.Users.Accounts.Register
{
    public static class RegisterCommand
    {
        public static BaseCommand<RegistrationDataDto> Command(RegistrationDataDto data) =>
            new BaseCommand<RegistrationDataDto>(data);

        [UsedImplicitly]
        internal class Handler : IRequestHandler<BaseCommand<RegistrationDataDto>>
        {
            private readonly IAuthenticationService _authenticationService;
            private readonly IUnitOfWork _unitOfWork;
            private readonly IRegistrationValidationService _registrationValidationService;

            public Handler(
                IAuthenticationService authenticationService,
                IUnitOfWork unitOfWork,
                IRegistrationValidationService registrationValidationService)
            {
                _authenticationService = authenticationService;
                _unitOfWork = unitOfWork;
                _registrationValidationService = registrationValidationService;
            }

            public async Task<Unit> Handle(
                BaseCommand<RegistrationDataDto> request,
                CancellationToken cancellationToken)
            {
                await _registrationValidationService.TrowsIfLoginIsNotUniq(request.Data.Login);
                await _authenticationService.SignUp(new RegistrationData
                {
                    Login = request.Data.Login,
                    Password = request.Data.Password,
                    UserType = request.Data.UserType,
                });
                await _unitOfWork.Commit();

                return Unit.Value;
            }
        }
    }
}