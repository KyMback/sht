using System.Threading.Tasks;
using SHT.Domain.Models.TestSessions.Students;
using SHT.Infrastructure.Common.ExecutionContext;
using SHT.Infrastructure.Common.StateMachine.Core;

namespace SHT.Domain.Services.Student.StateConfigurations.Guards
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