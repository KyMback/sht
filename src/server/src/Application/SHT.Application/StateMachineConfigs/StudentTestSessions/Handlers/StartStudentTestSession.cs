using System.Threading.Tasks;
using SHT.Application.StateMachineConfigs.Core;
using SHT.Domain.Models.TestSessions.Students;
using SHT.Domain.Services.Student;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Application.StateMachineConfigs.StudentTestSessions.Handlers
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
            var variant = context.DeserializeData(StudentTestSessionDataKey.TestVariant);
            await _studentTestSessionService.Start(context.Entity, variant);
            await _unitOfWork.Commit();
        }
    }
}