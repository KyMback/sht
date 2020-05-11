using System.Threading.Tasks;
using SHT.Application.StateMachineConfigs.Core;
using SHT.Domain.Models.Tests;
using SHT.Domain.Models.TestSessions;
using SHT.Domain.Models.TestSessions.Students;
using SHT.Domain.Services;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Application.StateMachineConfigs.StudentTestSessions.Guards
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
                State = TestSessionStates.Started,
            };

            return _unitOfWork.Any(queryParameters);
        }
    }
}