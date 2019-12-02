using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MediatR;
using SHT.Domain.Models.Users;
using SHT.Domain.Services.Users;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Application.Users.Students.SignUp
{
    [UsedImplicitly]
    internal class SignUpStudentHandler : IRequestHandler<SignUpStudentRequest>
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRegistrationValidationService _registrationValidationService;

        public SignUpStudentHandler(
            IAuthenticationService authenticationService,
            IUnitOfWork unitOfWork,
            IRegistrationValidationService registrationValidationService)
        {
            _authenticationService = authenticationService;
            _unitOfWork = unitOfWork;
            _registrationValidationService = registrationValidationService;
        }

        public async Task<Unit> Handle(
            SignUpStudentRequest request,
            CancellationToken cancellationToken)
        {
            var data = request.Data;
            await _registrationValidationService.TrowsIfEmailIsNotUniq(data.Email);
            var account = await _authenticationService.SignUp(new RegistrationData
            {
                Login = data.Email,
                Password = data.Password,
            });

            await _unitOfWork.Add(new Student
            {
                Account = account,
                FirstName = data.FirstName,
                LastName = data.LastName,
                Group = data.Group,
            });
            await _unitOfWork.Commit();

            return Unit.Value;
        }
    }
}