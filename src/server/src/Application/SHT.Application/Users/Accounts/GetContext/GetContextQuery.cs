using System;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MediatR;
using SHT.Domain.Services.Users;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Application.Users.Accounts.GetContext
{
    public static class GetContextQuery
    {
        public class Query : IRequest<UserContextDto>
        {
            public Guid Id { get; set; }
        }

        [UsedImplicitly]
        internal class Handler : IRequestHandler<Query, UserContextDto>
        {
            private readonly IUnitOfWork _unitOfWork;

            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public Task<UserContextDto> Handle(Query request, CancellationToken cancellationToken)
            {
                return _unitOfWork.GetSingleOrDefault(new UsersQueryParameters(request.Id), account => new UserContextDto
                {
                    Id = account.Id,
                    UserType = account.UserType,
                });
            }
        }
    }
}