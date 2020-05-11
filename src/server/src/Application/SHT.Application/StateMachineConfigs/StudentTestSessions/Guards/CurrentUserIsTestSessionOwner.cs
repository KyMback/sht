using System.Threading.Tasks;
using SHT.Application.StateMachineConfigs.Core;
using SHT.Domain.Models.TestSessions.Students;
using SHT.Domain.Services;
using SHT.Infrastructure.Common;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Application.StateMachineConfigs.StudentTestSessions.Guards
{
    internal class CurrentUserIsTestSessionOwner : IStateTransitionGuard<StudentTestSession>
    {
        private readonly IExecutionContextAccessor _executionContextAccessor;
        private readonly IUnitOfWork _unitOfWork;

        public CurrentUserIsTestSessionOwner(
            IExecutionContextAccessor executionContextAccessor,
            IUnitOfWork unitOfWork)
        {
            _executionContextAccessor = executionContextAccessor;
            _unitOfWork = unitOfWork;
        }

        public Task<bool> Check(StudentTestSession entity)
        {
            var queryParameters = new TestSessionQueryParameters
            {
                Id = entity.TestSessionId,
                InstructorId = _executionContextAccessor.GetCurrentUserId(),
            };

            return _unitOfWork.Any(queryParameters);
        }
    }
}