using System.Threading.Tasks;
using SHT.Application.StateMachineConfigs.Core;
using SHT.Domain.Models.TestSessions.Students;
using SHT.Infrastructure.Common;
using SHT.Infrastructure.Common.ExecutionContext;

namespace SHT.Application.StateMachineConfigs.StudentTestSessions.Guards
{
    internal class CurrentUserIsOwnerGuard : IStateTransitionGuard<StudentTestSession>
    {
        private readonly IExecutionContextService _executionContextService;

        public CurrentUserIsOwnerGuard(IExecutionContextService executionContextService)
        {
            _executionContextService = executionContextService;
        }

        public Task<bool> Check(StudentTestSession entity)
        {
            return Task.FromResult(entity.StudentId == _executionContextService.GetCurrentUserId());
        }
    }
}