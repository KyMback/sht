using System;
using System.Threading.Tasks;
using MoreLinq;
using SHT.Domain.Models.TestSessions;
using SHT.Domain.Models.TestSessions.Students;
using SHT.Infrastructure.Common.ExecutionContext;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Domain.Services
{
    internal class TestSessionService : ITestSessionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IExecutionContextService _executionContextService;

        public TestSessionService(
            IUnitOfWork unitOfWork,
            IExecutionContextService executionContextService)
        {
            _unitOfWork = unitOfWork;
            _executionContextService = executionContextService;
        }

        public async Task<TestSession> Create(TestSession session)
        {
            session.State = TestSessionState.Pending;
            session.InstructorId = _executionContextService.GetCurrentUserId();
            session.StudentTestSessions.ForEach(e => e.State = StudentTestSessionState.Pending);

            var result = await _unitOfWork.Add(session);
            await _unitOfWork.Commit();

            return result;
        }

        public async Task<TestSession> Update(TestSession session)
        {
            if (session.State != TestSessionState.Pending)
            {
                throw new InvalidOperationException("Can't update not pending test session");
            }

            session.StudentTestSessions.ForEach(e => e.State = StudentTestSessionState.Pending);

            await _unitOfWork.Update(session);
            await _unitOfWork.Commit();

            return session;
        }
    }
}