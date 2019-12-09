using System.Threading.Tasks;
using SHT.Application.StateMachineConfigs.Core;
using SHT.Domain.Models.Tests.Students;
using SHT.Infrastructure.Common;

namespace SHT.Application.StateMachineConfigs.StudentTestSessions.Guards
{
    internal class CurrentUserIsOwnerGuard : IStateTransitionGuard<StudentTestSession>
    {
        private readonly IExecutionContextAccessor _executionContextAccessor;

        public CurrentUserIsOwnerGuard(IExecutionContextAccessor executionContextAccessor)
        {
            _executionContextAccessor = executionContextAccessor;
        }

        public Task<bool> Check(StudentTestSession entity)
        {
            return Task.FromResult(entity.StudentId == _executionContextAccessor.GetCurrentUserId());
        }
    }
}