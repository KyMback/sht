using System.Linq;
using System.Threading.Tasks;
using SHT.Domain.Models.Tests.Students;

namespace SHT.Domain.Services.Tests
{
    internal class TestSessionService : ITestSessionService
    {
        public Task<TestSession> CreateTestSession(TestSessionCreationData data)
        {
            return Task.FromResult(new TestSession
            {
                StudentTestSessions = data.StudentsIds?.Select(id => new StudentTestSession
                {
                    StudentId = id,
                }).ToArray(),
                TestSessionTestVariants = data.TestVariantsIds?.Select(id => new TestSessionTestVariant
                {
                    TestVariantId = id,
                }).ToArray(),
                Name = data.Name,
                State = TestSessionStates.Pending,
                InstructorId = data.InstructorId,
            });
        }
    }
}