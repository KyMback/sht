using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MediatR;
using SHT.Domain.Models.Users;
using SHT.Domain.Services.Users.Accounts;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Application.Users.Accounts.ResendEmailConfirmation
{
    [UsedImplicitly]
    internal class ResendEmailConfirmationHandler : IRequestHandler<ResendEmailConfirmationRequest>
    {
        private readonly IUserAccountService _userAccountService;
        private readonly IUnitOfWork _unitOfWork;

        public ResendEmailConfirmationHandler(IUserAccountService userAccountService, IUnitOfWork unitOfWork)
        {
            _userAccountService = userAccountService;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(ResendEmailConfirmationRequest request, CancellationToken cancellationToken)
        {
            var queryParams = new AccountQueryParameters
            {
                NormalizedEmail = request.Email,
            };
            Account account = await _unitOfWork.GetSingle(queryParams);
            await _userAccountService.SendEmailConfirmation(account);
            return default;
        }
    }
}