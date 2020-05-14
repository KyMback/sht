using System;
using System.Threading.Tasks;
using SHT.Domain.Models.TestSessions.Students;
using SHT.Infrastructure.Common.ExecutionContext;
using SHT.Infrastructure.Common.StateMachine.Core;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Domain.Services.Student.StateConfigurations.Guards
{
    internal class CurrentUserIsOwnerOrTestSessionOwnerGuard : IStateTransitionGuard<StudentTestSession>
    {
        private readonly IExecutionContextService _executionContextService;
        private readonly IUnitOfWork _unitOfWork;

        public CurrentUserIsOwnerOrTestSessionOwnerGuard(
            IExecutionContextService executionContextService,
            IUnitOfWork unitOfWork)
        {
            _executionContextService = executionContextService;
            _unitOfWork = unitOfWork;
        }

        public Task<bool> Check(StudentTestSession entity)
        {
            Guid id = _executionContextService.GetCurrentUserId();

            if (entity.StudentId == id)
            {
                return Task.FromResult(true);
            }

            var queryParameters = new TestSessionQueryParameters
            {
                Id = entity.TestSessionId,
                InstructorId = _executionContextService.GetCurrentUserId(),
            };

            return _unitOfWork.Any(queryParameters);
        }
    }
}