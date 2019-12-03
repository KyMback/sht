using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MediatR;
using SHT.Domain.Models.Users;
using SHT.Domain.Services.Users;
using SHT.Infrastructure.Common.Transactions;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Application.Users.Students.SignUp
{
    [UsedImplicitly]
    internal class SignUpStudentHandler : IRequestHandler<SignUpStudentRequest>
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRegistrationValidationService _registrationValidationService;
        private readonly IUserAccountService _userAccountService;

        public SignUpStudentHandler(
            IAuthenticationService authenticationService,
            IUnitOfWork unitOfWork,
            IRegistrationValidationService registrationValidationService,
            IUserAccountService userAccountService)
        {
            _authenticationService = authenticationService;
            _unitOfWork = unitOfWork;
            _registrationValidationService = registrationValidationService;
            _userAccountService = userAccountService;
        }

        public async Task<Unit> Handle(
            SignUpStudentRequest request,
            CancellationToken cancellationToken)
        {
            var data = request.Data;
            await _registrationValidationService.TrowsIfEmailIsNotUniq(data.Email);
            using var scope = TransactionsFactory.Create();
            var account = await _authenticationService.SignUp(new RegistrationData
            {
                Email = data.Email,
                Password = data.Password,
                UserType = UserType.Student,
            });

            await _unitOfWork.Add(new Student
            {
                Account = account,
                FirstName = data.FirstName,
                LastName = data.LastName,
                Group = data.Group,
            });

            await _unitOfWork.Commit();
            await _userAccountService.SendEmailConfirmation(account);
            scope.Complete();

            return Unit.Value;
        }
    }
}