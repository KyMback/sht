using System.Threading.Tasks;
using SHT.Application.StateMachineConfigs.Core;
using SHT.Domain.Models.Tests;
using SHT.Domain.Models.TestSessions;
using SHT.Infrastructure.Common;
using SHT.Infrastructure.Common.ExecutionContext;

namespace SHT.Application.StateMachineConfigs.TestSessions.Guards
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