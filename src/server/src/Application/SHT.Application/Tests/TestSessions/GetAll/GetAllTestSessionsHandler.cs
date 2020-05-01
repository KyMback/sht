using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MediatR;
using SHT.Application.Tests.TestSessions.Contracts;
using SHT.Domain.Services;
using SHT.Infrastructure.Common;
using IQueryProvider = SHT.Infrastructure.DataAccess.Abstractions.IQueryProvider;

namespace SHT.Application.Tests.TestSessions.GetAll
{
    [UsedImplicitly]
    internal class GetAllTestSessionsHandler : IRequestHandler<GetAllTestSessionsRequest, IQueryable<TestSessionDetailsDto>>
    {
        private readonly IQueryProvider _queryProvider;
        private readonly IExecutionContextAccessor _executionContextAccessor;

        public GetAllTestSessionsHandler(IQueryProvider queryProvider, IExecutionContextAccessor executionContextAccessor)
        {
            _queryProvider = queryProvider;
            _executionContextAccessor = executionContextAccessor;
        }

        public Task<IQueryable<TestSessionDetailsDto>> Handle(GetAllTestSessionsRequest request, CancellationToken cancellationToken)
        {
            var queryParameters = new TestSessionQueryParameters
            {
                InstructorId = _executionContextAccessor.GetCurrentUserId(),
            };

            return Task.FromResult(queryParameters.ToQuery(_queryProvider).Select(TestSessionDetailsDto.Selector));
        }
    }
}