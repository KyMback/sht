using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MediatR;
using SHT.Application.Tests.StudentsTestSessions.FinalizeStudentsTestSessionsAction.Single;
using SHT.Common.Extensions;
using SHT.Domain.Models.TestSessions.Students;
using SHT.Domain.Services.Student;
using SHT.Infrastructure.BackgroundProcess;
using SHT.Infrastructure.BackgroundProcess.Execution;
using SHT.Infrastructure.BackgroundProcess.Interfaces;
using SHT.Infrastructure.Common;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Application.Tests.StudentsTestSessions.FinalizeStudentsTestSessionsAction.Batch
{
    [UsedImplicitly]
    internal class FinalizeStudentsTestSessionsHandler : IRequestHandler<FinalizeStudentsTestSessionsRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IBackgroundExecutionService _backgroundExecutionService;

        public FinalizeStudentsTestSessionsHandler(
            IUnitOfWork unitOfWork,
            IDateTimeProvider dateTimeProvider,
            IBackgroundExecutionService backgroundExecutionService)
        {
            _unitOfWork = unitOfWork;
            _dateTimeProvider = dateTimeProvider;
            _backgroundExecutionService = backgroundExecutionService;
        }

        public async Task<Unit> Handle(FinalizeStudentsTestSessionsRequest request, CancellationToken cancellationToken)
        {
            var queryParameters = new StudentTestSessionQueryParameters
            {
                State = StudentTestSessionState.Started,
                MoreOrGreaterThanShouldEndAt = _dateTimeProvider.UtcNow,
            };

            var sessionsData = await _unitOfWork.GetAll(queryParameters, session => new
            {
                StudentTestSessionId = session.Id,
                session.TestSession.InstructorId,
            });

            if (sessionsData.IsNullOrEmpty())
            {
                return default;
            }

            foreach (var group in sessionsData.GroupBy(e => e.InstructorId, e => e.StudentTestSessionId))
            {
                _backgroundExecutionService.Execute(
                    JobNames.FinalizeStudentTestSessionJob,
                    new FinalizeStudentTestSessionRequest(group.ToArray()),
                    new JobExecutionContext(group.Key));
            }

            return default;
        }
    }
}