using System;
using System.Threading.Tasks;
using AutoMapper;
using MoreLinq;
using SHT.Domain.Models.Tests;
using SHT.Domain.Models.TestSessions;
using SHT.Domain.Models.TestSessions.Students;
using SHT.Infrastructure.Common;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Domain.Services
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

        public async Task<TestSession> Create(TestSession session)
        {
            session.State = TestSessionStates.Pending;
            session.InstructorId = _executionContextAccessor.GetCurrentUserId();
            session.StudentTestSessions.ForEach(e => e.State = StudentTestSessionState.Pending);

            var result = await _unitOfWork.Add(session);
            await _unitOfWork.Commit();

            return result;
        }

        public async Task<TestSession> Update(TestSession session)
        {
            if (session.State != TestSessionStates.Pending)
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