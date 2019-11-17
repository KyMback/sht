using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MediatR;
using SHT.Domain.Services.Users;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Application.Users.Accounts.SignUp
{
    [UsedImplicitly]
    internal class SignUpHandler : IRequestHandler<SignUpRequest>
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRegistrationValidationService _registrationValidationService;

        public SignUpHandler(
            IAuthenticationService authenticationService,
            IUnitOfWork unitOfWork,
            IRegistrationValidationService registrationValidationService)
        {
            _authenticationService = authenticationService;
            _unitOfWork = unitOfWork;
            _registrationValidationService = registrationValidationService;
        }

        public async Task<Unit> Handle(
            SignUpRequest request,
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