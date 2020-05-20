using System;
using System.Threading.Tasks;
using AutoMapper;
using SHT.Common;
using SHT.Domain.Common.Exceptions;
using SHT.Domain.Models.Users;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Domain.Users.Accounts
{
    internal class UserAccountService : IUserAccountService
    {
        private readonly IUserEmailService _userEmailService;
        private readonly IUserManagementService<Account> _userManagementService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserAccountService(
            IUserEmailService userEmailService,
            IUserManagementService<Account> userManagementService,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _userEmailService = userEmailService;
            _userManagementService = userManagementService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Account> Create(AccountCreationData data)
        {
            var account = _mapper.Map<Account>(data);
            // TODO: currently set default organization
            account.OrganizationId = new Guid("D9A36195-6571-47A8-89EB-912E02C5512B");
            CommonResult result = await _userManagementService.Create(account, data.Password);
            if (!result.Succeeded)
            {
                throw new Exception(string.Join(", ", result.Errors));
            }

            return account;
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