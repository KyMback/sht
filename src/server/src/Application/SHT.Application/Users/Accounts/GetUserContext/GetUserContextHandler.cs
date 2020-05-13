using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MediatR;
using SHT.Application.Users.Accounts.Contracts;
using SHT.Domain.Users.Accounts;
using SHT.Infrastructure.Common;
using SHT.Infrastructure.Common.ExecutionContext;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Application.Users.Accounts.GetUserContext
{
    [UsedImplicitly]
    internal class GetUserContextHandler : IRequestHandler<GetUserContextRequest, UserContextDto>
    {
        private readonly IExecutionContextService _executionContextService;
        private readonly IUnitOfWork _unitOfWork;

        public GetUserContextHandler(IExecutionContextService executionContextService, IUnitOfWork unitOfWork)
        {
            _executionContextService = executionContextService;
            _unitOfWork = unitOfWork;
        }

        public async Task<UserContextDto> Handle(GetUserContextRequest request, CancellationToken cancellationToken)
        {
            var queryParameters = new AccountQueryParameters(_executionContextService.GetCurrentUserId());
            var data = await _unitOfWork.GetSingleOrDefault(queryParameters, UserContextDto.Selector);

            if (data != null)
            {
                data.IsAuthenticated = true;
                data.Culture = CultureInfo.CurrentCulture.Name;
            }

            return data ?? new UserContextDto
            {
                Culture = CultureInfo.CurrentCulture.Name,
            };
        }
    }
}