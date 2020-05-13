using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MediatR;
using SHT.Application.Tests.StudentsTestSessions.Contracts;
using SHT.Domain.Models.Tests;
using SHT.Domain.Models.TestSessions;
using SHT.Domain.Services.Student;
using SHT.Infrastructure.Common;
using IQueryProvider = SHT.Infrastructure.DataAccess.Abstractions.QueryParameters.IQueryProvider;

namespace SHT.Application.Tests.StudentsTestSessions.GetAll
{
    [UsedImplicitly]
    internal class GetAllStudentTestSessionsHandler :
        IRequestHandler<GetAllStudentTestSessionsRequest, IQueryable<StudentTestSessionDto>>
    {
        private readonly IQueryProvider _queryProvider;
        private readonly IExecutionContextAccessor _executionContextAccessor;

        public GetAllStudentTestSessionsHandler(
            IQueryProvider queryProvider,
            IExecutionContextAccessor executionContextAccessor)
        {
            _queryProvider = queryProvider;
            _executionContextAccessor = executionContextAccessor;
        }

        public Task<IQueryable<StudentTestSessionDto>> Handle(
            GetAllStudentTestSessionsRequest request,
            CancellationToken cancellationToken)
        {
            var queryParameters = new StudentTestSessionQueryParameters
            {
                StudentId = _executionContextAccessor.GetCurrentUserId(),
                ExceptTestSessionState = TestSessionStates.Pending,
            };

            return Task.FromResult(_queryProvider.Queryable(queryParameters).Select(StudentTestSessionDto.Selector));
        }
    }
}