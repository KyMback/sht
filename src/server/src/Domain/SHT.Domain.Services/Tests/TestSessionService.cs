using System.Linq;
using System.Threading.Tasks;
using SHT.Domain.Models.Tests;
using SHT.Domain.Models.Tests.Students;
using SHT.Infrastructure.Common;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Domain.Services.Tests
{
    internal class TestSessionService : ITestSessionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IExecutionContextAccessor _executionContextAccessor;

        public TestSessionService(
            IUnitOfWork unitOfWork,
            IExecutionContextAccessor executionContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _executionContextAccessor = executionContextAccessor;
        }

        public Task<TestSession> CreateTestSession(string name)
        {
            var session = new TestSession
            {
                Name = name,
                State = TestSessionStates.Pending,
                InstructorId = _executionContextAccessor.GetCurrentUserId(),
            };

            return _unitOfWork.Add(session);
        }

        public async Task LinkStudents(StudentTestSessionLinkData linkData)
        {
            // TODO: can be optimized
            await _unitOfWork.DeleteRange(linkData.TestSession.StudentTestSessions);

            linkData.TestSession.StudentTestSessions = linkData.StudentIds.Select(e => new StudentTestSession
            {
                State = StudentTestSessionState.Pending,
                StudentId = e,
                TestSessionId = linkData.TestSession.Id,
            }).ToList();

            await _unitOfWork.Update(linkData.TestSession);
        }

        public async Task LinkVariants(TestSessionVariantsLinkData linkData)
        {
            // TODO: can be optimized
            await _unitOfWork.DeleteRange(linkData.TestSession.TestSessionTestVariants);
            linkData.TestSession.TestSessionTestVariants = linkData.TestVariants.Select(e => new TestSessionTestVariant
            {
                Name = e.Key,
                TestSessionId = linkData.TestSession.Id,
                TestVariantId = e.Value,
            }).ToList();

            await _unitOfWork.Update(linkData.TestSession);
        }
    }
}