using System.Threading.Tasks;
using SHT.Domain.Services.Exceptions;
using SHT.Domain.Services.Users.Accounts;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Domain.Services.Users
{
    internal class RegistrationValidationService : IRegistrationValidationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RegistrationValidationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task TrowsIfEmailIsNotUniq(string email)
        {
            if (await _unitOfWork.Any(new AccountQueryParameters(normalizedEmail: email)))
            {
                throw new CodedException(ErrorCode.LoginIsNotUniq);
            }
        }
    }
}