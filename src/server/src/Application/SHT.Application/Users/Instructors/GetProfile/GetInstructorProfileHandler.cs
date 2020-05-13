using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MediatR;
using SHT.Application.Users.Instructors.Contracts;
using SHT.Domain.Users;
using SHT.Infrastructure.Common;
using SHT.Infrastructure.Common.ExecutionContext;
using IQueryProvider = SHT.Infrastructure.DataAccess.Abstractions.QueryParameters.IQueryProvider;

namespace SHT.Application.Users.Instructors.GetProfile
{
    [UsedImplicitly]
    internal class GetInstructorProfileHandler :
        IRequestHandler<GetInstructorProfileRequest, IQueryable<InstructorDto>>
    {
        private readonly IQueryProvider _queryProvider;
        private readonly IExecutionContextService _executionContextService;

        public GetInstructorProfileHandler(
            IQueryProvider queryProvider,
            IExecutionContextService executionContextService)
        {
            _queryProvider = queryProvider;
            _executionContextService = executionContextService;
        }

        public Task<IQueryable<InstructorDto>> Handle(GetInstructorProfileRequest request, CancellationToken cancellationToken)
        {
            var queryParameters = new InstructorQueryParameters(_executionContextService.GetCurrentUserId());

            return Task.FromResult(_queryProvider.Queryable(queryParameters).Select(InstructorDto.Selector));
        }
    }
}