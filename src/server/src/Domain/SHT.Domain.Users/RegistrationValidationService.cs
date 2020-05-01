using System.Threading.Tasks;
using SHT.Domain.Common.Exceptions;
using SHT.Domain.Users.Accounts;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Domain.Users
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