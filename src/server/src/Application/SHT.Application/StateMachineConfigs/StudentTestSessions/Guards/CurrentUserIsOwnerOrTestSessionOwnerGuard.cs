using System.Threading.Tasks;
using SHT.Application.StateMachineConfigs.Core;
using SHT.Domain.Models.Tests.Students;
using SHT.Domain.Services;
using SHT.Infrastructure.Common;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Application.StateMachineConfigs.StudentTestSessions.Guards
{
    internal class CurrentUserIsOwnerOrTestSessionOwnerGuard : IStateTransitionGuard<StudentTestSession>
    {
        private readonly IExecutionContextAccessor _executionContextAccessor;
        private readonly IUnitOfWork _unitOfWork;

        public CurrentUserIsOwnerOrTestSessionOwnerGuard(
            IExecutionContextAccessor executionContextAccessor,
            IUnitOfWork unitOfWork)
        {
            _executionContextAccessor = executionContextAccessor;
            _unitOfWork = unitOfWork;
        }

        public Task<bool> Check(StudentTestSession entity)
        {
            var id = _executionContextAccessor.GetCurrentUserId();

            if (entity.StudentId == id)
            {
                return Task.FromResult(true);
            }

            var queryParameters = new TestSessionQueryParameters
            {
                Id = entity.TestSessionId,
                InstructorId = _executionContextAccessor.GetCurrentUserId(),
            };

            return _unitOfWork.Any(queryParameters);
        }
    }
}