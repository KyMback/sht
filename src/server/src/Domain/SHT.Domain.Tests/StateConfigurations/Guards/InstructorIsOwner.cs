using System.Threading.Tasks;
using SHT.Domain.Models.TestSessions;
using SHT.Infrastructure.Common.ExecutionContext;
using SHT.Infrastructure.Common.StateMachine.Core;

namespace SHT.Domain.Services.StateConfigurations.Guards
{
    internal class InstructorIsOwner : IStateTransitionGuard<TestSession>
    {
        private readonly IExecutionContextService _executionContextService;

        public InstructorIsOwner(IExecutionContextService executionContextService)
        {
            _executionContextService = executionContextService;
        }

        public Task<bool> Check(TestSession entity)
        {
            return Task.FromResult(entity.InstructorId == _executionContextService.GetCurrentUserId());
        }
    }
}