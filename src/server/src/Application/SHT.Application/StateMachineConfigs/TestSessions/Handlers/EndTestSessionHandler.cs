using System.Linq;
using System.Threading.Tasks;
using SHT.Application.StateMachineConfigs.Core;
using SHT.Application.StateMachineConfigs.StudentTestSessions;
using SHT.Domain.Models.Tests;
using SHT.Domain.Models.Tests.Students;
using SHT.Domain.Services.Tests.Student;
using SHT.Infrastructure.Common.Transactions;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Application.StateMachineConfigs.TestSessions.Handlers
{
    internal class EndTestSessionHandler : IStateTransitionHandler<TestSession>
    {
        private readonly IStateManager<StudentTestSession> _stateManager;
        private readonly IUnitOfWork _unitOfWork;

        public EndTestSessionHandler(IStateManager<StudentTestSession> stateManager, IUnitOfWork unitOfWork)
        {
            _stateManager = stateManager;
            _unitOfWork = unitOfWork;
        }

        public async Task Transit(StateTransitionContext<TestSession> context)
        {
            var queryParameters = new StudentTestSessionQueryParameters
            {
                TestSessionId = context.Entity.Id,
                ExcludedStates = new[] { StudentTestSessionState.Ended },
                IsReadOnly = false,
            };
            var studentTestSessions = await _unitOfWork.GetAll(queryParameters);

            using var scope = TransactionsFactory.Create();

            foreach (var session in studentTestSessions.Where(e => e.State == StudentTestSessionState.Started))
            {
                await _stateManager.Process(session, StudentTestSessionTriggers.EndTest);
            }

            await _unitOfWork.Commit();

            foreach (var session in studentTestSessions.Where(e => e.State == StudentTestSessionState.Pending))
            {
                await _stateManager.Process(session, StudentTestSessionTriggers.OverdueTest);
            }

            await _unitOfWork.Commit();
            scope.Complete();
        }
    }
}