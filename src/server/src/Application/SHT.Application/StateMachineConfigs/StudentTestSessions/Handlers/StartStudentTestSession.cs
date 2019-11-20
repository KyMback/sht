using System.Threading.Tasks;
using SHT.Application.StateMachineConfigs.Core;
using SHT.Domain.Models.Tests.Students;

namespace SHT.Application.StateMachineConfigs.StudentTestSessions.Handlers
{
    internal class StartStudentTestSession : IStateTransitionHandler<StudentTestSession>
    {
        public Task Transit(StateTransitionContext<StudentTestSession> context)
        {
            return Task.CompletedTask;
        }
    }
}