using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MoreLinq;
using SHT.Domain.Models.TestSessions;
using SHT.Domain.Models.TestSessions.Students;
using SHT.Domain.Services.Student;
using SHT.Domain.Services.TestSessionAssessments;
using SHT.Infrastructure.Common.ExecutionContext;
using SHT.Infrastructure.Common.Transactions;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Domain.Services
{
    internal class TestSessionService : ITestSessionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IExecutionContextService _executionContextService;
        private readonly IStudentTestSessionService _studentTestSessionService;
        private readonly ITestSessionAssessmentService _testSessionAssessmentService;

        public TestSessionService(
            IUnitOfWork unitOfWork,
            IExecutionContextService executionContextService,
            IStudentTestSessionService studentTestSessionService,
            ITestSessionAssessmentService testSessionAssessmentService)
        {
            _unitOfWork = unitOfWork;
            _executionContextService = executionContextService;
            _studentTestSessionService = studentTestSessionService;
            _testSessionAssessmentService = testSessionAssessmentService;
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

        public async Task StartAssessmentPhase(TestSession testSession)
        {
            var queryParameters = new StudentTestSessionQueryParameters
            {
                TestSessionId = testSession.Id,
                ExcludedStates = new[] { StudentTestSessionState.Ended },
                IsReadOnly = false,
            };
            IReadOnlyCollection<StudentTestSession> studentTestSessions = await _unitOfWork.GetAll(queryParameters);

            using var scope = TransactionsFactory.Create();
            await _studentTestSessionService.EndTests(studentTestSessions);
            await _testSessionAssessmentService.CreateAssessmentQuestions(testSession.Assessment);
            scope.Complete();
        }
    }
}