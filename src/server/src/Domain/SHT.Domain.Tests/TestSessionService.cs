using System;
using System.Threading.Tasks;
using AutoMapper;
using MoreLinq;
using SHT.Domain.Models.Tests;
using SHT.Domain.Models.Tests.Students;
using SHT.Infrastructure.Common;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Domain.Services
{
    internal class TestSessionService : ITestSessionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IExecutionContextAccessor _executionContextAccessor;
        private readonly IMapper _mapper;

        public TestSessionService(
            IUnitOfWork unitOfWork,
            IExecutionContextAccessor executionContextAccessor,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _executionContextAccessor = executionContextAccessor;
            _mapper = mapper;
        }

        public async Task<TestSession> Create(TestSessionModificationData data)
        {
            var session = _mapper.Map<TestSession>(data);
            session.State = TestSessionStates.Pending;
            session.InstructorId = _executionContextAccessor.GetCurrentUserId();
            session.StudentTestSessions.ForEach(e => e.State = StudentTestSessionState.Pending);

            var result = await _unitOfWork.Add(session);
            await _unitOfWork.Commit();

            return result;
        }

        public async Task<TestSession> Update(TestSession original, TestSessionModificationData data)
        {
            if (original.State != TestSessionStates.Pending)
            {
                throw new InvalidOperationException("Can't update not pending test session");
            }

            _mapper.Map(data, original);
            original.StudentTestSessions.ForEach(e => e.State = StudentTestSessionState.Pending);

            await _unitOfWork.Update(original);
            await _unitOfWork.Commit();

            return original;
        }
    }
}