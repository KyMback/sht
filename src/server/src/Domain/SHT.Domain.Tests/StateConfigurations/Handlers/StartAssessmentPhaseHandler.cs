using System.Threading.Tasks;
using SHT.Domain.Models.TestSessions;
using SHT.Infrastructure.Common.StateMachine.Core;

namespace SHT.Domain.Services.StateConfigurations.Handlers
{
    internal class StartAssessmentPhaseHandler : IStateTransitionHandler<TestSession>
    {
        private readonly ITestSessionService _testSessionService;

        public StartAssessmentPhaseHandler(
            ITestSessionService testSessionService)
        {
            _testSessionService = testSessionService;
        }

        public Task Transit(StateTransitionContext<TestSession> context)
        {
            return _testSessionService.StartAssessmentPhase(context.Entity);
        }
    }
}