using System.Threading.Tasks;
using SHT.Application.StateMachineConfigs.Core;
using SHT.Domain.Models.TestSessions;

namespace SHT.Application.StateMachineConfigs.TestSessions.Handlers
{
    internal class StartTestSessionHandler : IStateTransitionHandler<TestSession>
    {
        public Task Transit(StateTransitionContext<TestSession> context)
        {
            return Task.CompletedTask;
        }
    }
}