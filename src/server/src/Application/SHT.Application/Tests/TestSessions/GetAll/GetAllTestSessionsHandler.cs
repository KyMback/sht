using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MediatR;
using SHT.Application.Tests.TestSessions.Contracts;
using SHT.Domain.Services;
using SHT.Infrastructure.Common;
using SHT.Infrastructure.Common.ExecutionContext;
using IQueryProvider = SHT.Infrastructure.DataAccess.Abstractions.QueryParameters.IQueryProvider;

namespace SHT.Application.Tests.TestSessions.GetAll
{
    [UsedImplicitly]
    internal class GetAllTestSessionsHandler : IRequestHandler<GetAllTestSessionsRequest, IQueryable<TestSessionDto>>
    {
        private readonly IQueryProvider _queryProvider;
        private readonly IExecutionContextService _executionContextService;

        public GetAllTestSessionsHandler(IQueryProvider queryProvider, IExecutionContextService executionContextService)
        {
            _queryProvider = queryProvider;
            _executionContextService = executionContextService;
        }

        public Task<IQueryable<TestSessionDto>> Handle(GetAllTestSessionsRequest request, CancellationToken cancellationToken)
        {
            var queryParameters = new TestSessionQueryParameters
            {
                InstructorId = _executionContextService.GetCurrentUserId(),
            };

            return Task.FromResult(_queryProvider.Queryable(queryParameters).Select(TestSessionDto.Selector));
        }
    }
}