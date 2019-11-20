using System.Linq;
using System.Threading.Tasks;
using SHT.Domain.Models.Tests;
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

        public Task<TestSession> CreateTestSession(TestSessionCreationData data)
        {
            var session = new TestSession
            {
                TestSessionTestVariants = data.TestVariantsIds?.Select(id => new TestSessionTestVariant
                {
                    TestVariantId = id,
                }).ToArray(),
                Name = data.Name,
                State = TestSessionStates.Pending,
                InstructorId = _executionContextAccessor.GetCurrentUserId(),
            };

            return _unitOfWork.Add(session);
        }
    }
}