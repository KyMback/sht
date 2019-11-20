using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MediatR;
using SHT.Domain.Services.Tests.Student;
using SHT.Infrastructure.Common;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Application.Tests.TestSessions.Students.GetAll
{
    [UsedImplicitly]
    internal class GetAllStudentTestSessionsHandler : IRequestHandler<GetAllStudentTestSessionsRequest,
        IReadOnlyCollection<StudentTestSessionDto>>
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

        public Task<IReadOnlyCollection<StudentTestSessionDto>> Handle(
            GetAllStudentTestSessionsRequest request,
            CancellationToken cancellationToken)
        {
            var queryParameters = new StudentTestSessionQueryParameters
            {
                State = request.State,
                StudentId = _executionContextAccessor.GetCurrentUserId(),
            };

            return _unitOfWork.GetAll(queryParameters, session => new StudentTestSessionDto
            {
                Id = session.Id,
                State = session.State,
                TestNumber = session.TestNumber,
                TestSessionId = session.TestSessionId,
            });
        }
    }
}