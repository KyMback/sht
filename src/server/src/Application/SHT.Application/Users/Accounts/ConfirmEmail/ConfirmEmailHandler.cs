using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MediatR;
using SHT.Domain.Services.Users.Accounts;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Application.Users.Accounts.ConfirmEmail
{
    [UsedImplicitly]
    internal class ConfirmEmailHandler : IRequestHandler<ConfirmEmailRequest>
    {
        private readonly IUserAccountService _userAccountService;
        private readonly IUnitOfWork _unitOfWork;

        public ConfirmEmailHandler(IUserAccountService userAccountService, IUnitOfWork unitOfWork)
        {
            _userAccountService = userAccountService;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(ConfirmEmailRequest request, CancellationToken cancellationToken)
        {
            await _userAccountService.ConfirmEmail(request.Data.Email, request.Data.Token);
            await _unitOfWork.Commit();
            return default;
        }
    }
}