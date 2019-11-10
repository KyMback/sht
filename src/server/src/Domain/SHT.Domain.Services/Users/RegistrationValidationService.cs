using System.Threading.Tasks;
using SHT.Domain.Services.Exceptions;
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

        public async Task TrowsIfLoginIsNotUniq(string login)
        {
            if (await _unitOfWork.Any(new UsersQueryParameters(login: login)))
            {
                throw new CodedException(ErrorCode.LoginIsNotUniq);
            }
        }
    }
}