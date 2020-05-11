using System.Threading.Tasks;
using SHT.Application.StateMachineConfigs.Core;
using SHT.Domain.Models.Tests;
using SHT.Domain.Models.TestSessions;
using SHT.Infrastructure.Common;

namespace SHT.Application.StateMachineConfigs.TestSessions.Guards
{
    internal class InstructorIsOwner : IStateTransitionGuard<TestSession>
    {
        private readonly IExecutionContextAccessor _executionContextAccessor;

        public InstructorIsOwner(IExecutionContextAccessor executionContextAccessor)
        {
            _executionContextAccessor = executionContextAccessor;
        }

        public Task<bool> Check(TestSession entity)
        {
            return Task.FromResult(entity.InstructorId == _executionContextAccessor.GetCurrentUserId());
        }
    }
}