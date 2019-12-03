using System.Threading.Tasks;
using SHT.Domain.Models.Users;
using SHT.Domain.Services.Exceptions;
using SHT.Domain.Services.Users.Accounts;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Domain.Services.Users
{
    internal class UserAccountService : IUserAccountService
    {
        private readonly IUserEmailService _userEmailService;
        private readonly IUserManagementService<Account> _userManagementService;
        private readonly IUnitOfWork _unitOfWork;

        public UserAccountService(
            IUserEmailService userEmailService,
            IUserManagementService<Account> userManagementService,
            IUnitOfWork unitOfWork)
        {
            _userEmailService = userEmailService;
            _userManagementService = userManagementService;
            _unitOfWork = unitOfWork;
        }

        public async Task SendEmailConfirmation(Account account)
        {
            var token = await _userManagementService.GenerateEmailConfirmToken(account);
            await _userEmailService.SendEmailConfirmationEmail(account.Email, token);
        }

        public async Task ConfirmEmail(string email, string token)
        {
            var queryParameters = new AccountQueryParameters(email: email)
            {
                IsReadOnly = false,
            };
            Account account = await _unitOfWork.GetSingle(queryParameters);
            var result = await _userManagementService.ConfirmEmail(account, token);

            if (!result.Succeeded)
            {
                throw new CodedException(ErrorCode.InvalidEmailConfirmationToken);
            }
        }
    }
}