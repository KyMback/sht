using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MediatR;
using SHT.Common.Extensions;
using SHT.Domain.Models.TestSessions.Students;
using SHT.Domain.Services.Student;
using SHT.Domain.Services.Student.StateConfigurations;
using SHT.Infrastructure.Common.StateMachine.Core;
using SHT.Infrastructure.Common.Transactions;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Application.Tests.StudentsTestSessions.FinalizeStudentsTestSessionsAction.Single
{
    [UsedImplicitly]
    internal class FinalizeStudentTestSessionHandler : IRequestHandler<FinalizeStudentTestSessionRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStateManager<StudentTestSession> _studentTestSessionManager;

        public FinalizeStudentTestSessionHandler(
            IUnitOfWork unitOfWork,
            IStateManager<StudentTestSession> studentTestSessionManager)
        {
            _unitOfWork = unitOfWork;
            _studentTestSessionManager = studentTestSessionManager;
        }

        public async Task<Unit> Handle(FinalizeStudentTestSessionRequest request, CancellationToken cancellationToken)
        {
            var queryParameters = new StudentTestSessionQueryParameters
            {
                Ids = request.StudentTestSessionIds,
                State = StudentTestSessionState.Started,
                IsReadOnly = false,
            };

            var sessions = await _unitOfWork.GetAll(queryParameters);

            if (sessions.IsNullOrEmpty())
            {
                return default;
            }

            using var scope = TransactionsFactory.Create();

            foreach (var session in sessions)
            {
                await _studentTestSessionManager.Process(session, StudentTestSessionTriggers.EndTest);
            }

            await _unitOfWork.Commit();
            scope.Complete();

            return default;
        }
    }
}