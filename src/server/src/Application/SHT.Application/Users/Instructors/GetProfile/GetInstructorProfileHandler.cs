using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MediatR;
using SHT.Application.Users.Instructors.Contracts;
using SHT.Domain.Users;
using SHT.Infrastructure.Common;
using IQueryProvider = SHT.Infrastructure.DataAccess.Abstractions.IQueryProvider;

namespace SHT.Application.Users.Instructors.GetProfile
{
    [UsedImplicitly]
    internal class GetInstructorProfileHandler :
        IRequestHandler<GetInstructorProfileRequest, IQueryable<InstructorProfileDto>>
    {
        private readonly IQueryProvider _queryProvider;
        private readonly IExecutionContextAccessor _executionContextAccessor;

        public GetInstructorProfileHandler(
            IQueryProvider queryProvider,
            IExecutionContextAccessor executionContextAccessor)
        {
            _queryProvider = queryProvider;
            _executionContextAccessor = executionContextAccessor;
        }

        public Task<IQueryable<InstructorProfileDto>> Handle(GetInstructorProfileRequest request, CancellationToken cancellationToken)
        {
            var queryParameters = new InstructorQueryParameters(_executionContextAccessor.GetCurrentUserId());

            return Task.FromResult(queryParameters.ToQuery(_queryProvider).Select(InstructorProfileDto.Selector));
        }
    }
}