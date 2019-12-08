using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MediatR;
using SHT.Domain.Services.Tests.Student;
using SHT.Infrastructure.Common;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Application.Tests.StudentsTestSessions.Get
{
    [UsedImplicitly]
    internal class GetStudentTestSessionHandler :
        IRequestHandler<GetStudentTestSessionRequest, StudentTestSessionDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IExecutionContextAccessor _executionContextAccessor;

        public GetStudentTestSessionHandler(
            IUnitOfWork unitOfWork,
            IExecutionContextAccessor executionContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _executionContextAccessor = executionContextAccessor;
        }

        public Task<StudentTestSessionDto> Handle(
            GetStudentTestSessionRequest request,
            CancellationToken cancellationToken)
        {
            var queryParameters = new StudentTestSessionQueryParameters
            {
                Id = request.Id,
                StudentId = _executionContextAccessor.GetCurrentUserId(),
            };

            return _unitOfWork.GetSingle(queryParameters, session => new StudentTestSessionDto
            {
                State = session.State,
                Name = session.TestSession.Name,
                Variant = session.TestVariant,
            });
        }
    }
}