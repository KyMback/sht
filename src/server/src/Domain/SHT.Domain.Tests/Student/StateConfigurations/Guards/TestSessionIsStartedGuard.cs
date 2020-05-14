using System.Threading.Tasks;
using SHT.Domain.Models.TestSessions;
using SHT.Domain.Models.TestSessions.Students;
using SHT.Infrastructure.Common.StateMachine.Core;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Domain.Services.Student.StateConfigurations.Guards
{
    internal class TestSessionIsStartedGuard : IStateTransitionGuard<StudentTestSession>
    {
        private readonly IUnitOfWork _unitOfWork;

        public TestSessionIsStartedGuard(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<bool> Check(StudentTestSession entity)
        {
            var queryParameters = new TestSessionQueryParameters(entity.TestSessionId)
            {
                State = TestSessionState.Started,
            };

            return _unitOfWork.Any(queryParameters);
        }
    }
}