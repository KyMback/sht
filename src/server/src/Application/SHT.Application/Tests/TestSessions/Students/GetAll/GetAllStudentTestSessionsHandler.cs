using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MediatR;
using SHT.Application.Common.Tables;
using SHT.Domain.Services.Tests.Student;
using SHT.Infrastructure.Common;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Application.Tests.TestSessions.Students.GetAll
{
    [UsedImplicitly]
    internal class GetAllStudentTestSessionsHandler : IRequestHandler<GetAllStudentTestSessionsRequest,
        TableResult<StudentTestSessionDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IExecutionContextAccessor _executionContextAccessor;

        public GetAllStudentTestSessionsHandler(
            IUnitOfWork unitOfWork,
            IExecutionContextAccessor executionContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _executionContextAccessor = executionContextAccessor;
        }

        public async Task<TableResult<StudentTestSessionDto>> Handle(
            GetAllStudentTestSessionsRequest request,
            CancellationToken cancellationToken)
        {
            var filter = request.Data;
            var queryParameters = new StudentTestSessionQueryParameters
            {
                PagingSettings = new PageSettings(filter.PageNumber, filter.PageSize),
                OrderDescByTestSessionCreatedAt = true,
                StudentId = _executionContextAccessor.GetCurrentUserId(),
            };

            var result = await _unitOfWork.GetSearchResult(queryParameters, session => new StudentTestSessionDto
            {
                Id = session.Id,
                State = session.State,
                Name = session.TestSession.Name,
                TestVariant = session.TestVariant,
            });

            return new TableResult<StudentTestSessionDto>(result.Items, result.Total);
        }
    }
}