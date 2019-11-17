using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MediatR;
using SHT.Domain.Services.Users;
using SHT.Infrastructure.Common;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Application.Users.Accounts.GetContext
{
    [UsedImplicitly]
    internal class GetContextHandler : IRequestHandler<GetContextRequest, UserContextDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IExecutionContextAccessor _executionContextAccessor;

        public GetContextHandler(IUnitOfWork unitOfWork, IExecutionContextAccessor executionContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _executionContextAccessor = executionContextAccessor;
        }

        public async Task<UserContextDto> Handle(GetContextRequest request, CancellationToken cancellationToken)
        {
            var data = await _unitOfWork.GetSingleOrDefault(
                new UsersQueryParameters(_executionContextAccessor.GetCurrentUserId()),
                account =>
                    new UserContextDto
                    {
                        Id = account.Id,
                        UserType = account.UserType,
                    });

            if (data == null)
            {
                return new UserContextDto
                {
                    IsAuthenticated = false,
                };
            }

            data.IsAuthenticated = true;
            return data;
        }
    }
}