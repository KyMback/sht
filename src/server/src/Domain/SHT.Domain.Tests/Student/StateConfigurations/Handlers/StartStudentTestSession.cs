using System;
using System.Threading.Tasks;
using SHT.Domain.Models.TestSessions.Students;
using SHT.Infrastructure.Common.StateMachine.Core;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Domain.Services.Student.StateConfigurations.Handlers
{
    internal class StartStudentTestSession : IStateTransitionHandler<StudentTestSession>
    {
        private readonly IStudentTestSessionService _studentTestSessionService;
        private readonly IUnitOfWork _unitOfWork;

        public StartStudentTestSession(
            IStudentTestSessionService studentTestSessionService,
            IUnitOfWork unitOfWork)
        {
            _studentTestSessionService = studentTestSessionService;
            _unitOfWork = unitOfWork;
        }

        public async Task Transit(StateTransitionContext<StudentTestSession> context)
        {
            var variantId = Guid.Parse(context.SerializedData[StudentTestSessionDataKey.TestVariant]);
            await _studentTestSessionService.Start(context.Entity, variantId);
            await _unitOfWork.Commit();
        }
    }
}