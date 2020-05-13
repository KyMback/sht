using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MediatR;
using SHT.Application.Common;
using SHT.Domain.Services;
using SHT.Infrastructure.Common;
using IQueryProvider = SHT.Infrastructure.DataAccess.Abstractions.QueryParameters.IQueryProvider;

namespace SHT.Application.Tests.StudentsTestSessions.GetVariants
{
    [UsedImplicitly]
    internal class GetStudentTestSessionVariantsHandler :
        IRequestHandler<GetStudentTestSessionVariantsRequest, IQueryable<Lookup>>
    {
        private readonly IExecutionContextAccessor _executionContextAccessor;
        private readonly IQueryProvider _queryProvider;

        public GetStudentTestSessionVariantsHandler(
            IExecutionContextAccessor executionContextAccessor,
            IQueryProvider queryProvider)
        {
            _executionContextAccessor = executionContextAccessor;
            _queryProvider = queryProvider;
        }

        public Task<IQueryable<Lookup>> Handle(
            GetStudentTestSessionVariantsRequest request,
            CancellationToken cancellationToken)
        {
            var queryParameters = new TestSessionVariantsQueryParameters
            {
                StudentTestSessionId = request.StudentTestSessionId,
                StudentId = _executionContextAccessor.GetCurrentUserId(),
            };

            return Task.FromResult(_queryProvider.Queryable(queryParameters)
                .Select(e => new Lookup(e.Name, e.Id.ToString())));
        }
    }
}