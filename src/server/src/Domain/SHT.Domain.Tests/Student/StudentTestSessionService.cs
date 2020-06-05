using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SHT.Common.Utils;
using SHT.Domain.Common.Exceptions;
using SHT.Domain.Models.Tests;
using SHT.Domain.Models.TestSessions.Assessments;
using SHT.Domain.Models.TestSessions.Students;
using SHT.Domain.Models.TestSessions.Students.Answers;
using SHT.Domain.Models.TestSessions.Variants;
using SHT.Domain.Services.Student.StateConfigurations;
using SHT.Infrastructure.Common;
using SHT.Infrastructure.Common.StateMachine.Core;
using SHT.Infrastructure.Common.Transactions;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Domain.Services.Student
{
    internal class StudentTestSessionService : IStudentTestSessionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStateManager<StudentTestSession> _stateManager;
        private readonly IDateTimeProvider _dateTimeProvider;

        public StudentTestSessionService(
            IUnitOfWork unitOfWork,
            IStateManager<StudentTestSession> stateManager,
            IDateTimeProvider dateTimeProvider)
        {
            _unitOfWork = unitOfWork;
            _stateManager = stateManager;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task Start(StudentTestSession studentTestSession, Guid variantId)
        {
            var queryParams = new TestSessionVariantsQueryParameters
            {
                Id = variantId,
                TestSessionId = studentTestSession.TestSessionId,
                IsReadOnly = false,
            };

            var testVariant = await _unitOfWork.GetSingleOrDefault(queryParams);
            if (testVariant == null)
            {
                throw new CodedException(ErrorCode.InvalidVariantName);
            }

            if (studentTestSession.TestSession.StudentTestDuration.HasValue)
            {
                studentTestSession.ShouldEndAt =
                    _dateTimeProvider.UtcNow.Add(studentTestSession.TestSession.StudentTestDuration.Value);
            }

            studentTestSession.TestVariantId = variantId;
            studentTestSession.Questions = GenerateQuestions(testVariant);
            await _unitOfWork.Update(studentTestSession);
        }

        public async Task EndTests(IReadOnlyCollection<StudentTestSession> studentTestSessions)
        {
            using var scope = TransactionsFactory.Create();

            foreach (var session in studentTestSessions.Where(e => e.State == StudentTestSessionState.Started))
            {
                await _stateManager.Process(session, StudentTestSessionTriggers.EndTest);
            }

            await _unitOfWork.Commit();

            foreach (var session in studentTestSessions.Where(e => e.State == StudentTestSessionState.Pending))
            {
                await _stateManager.Process(session, StudentTestSessionTriggers.OverdueTest);
            }

            await _unitOfWork.Commit();
            scope.Complete();
        }

        private IList<StudentTestSessionQuestion> GenerateQuestions(TestSessionVariant variant)
        {
            IReadOnlyList<int> orderNumbers = new List<int>(0);
            if (variant.IsRandomOrder)
            {
                orderNumbers = RandomUtils.GenerateRandomSequence(1, variant.Questions.Count);
            }

            return variant.Questions.Select((e, index) => new StudentTestSessionQuestion
            {
                QuestionId = e.Id,
                Order = variant.IsRandomOrder ? orderNumbers[index] : e.Order.Value,
                Answer = new StudentQuestionAnswer
                {
                    FreeTextAnswer = e.Type == QuestionType.FreeText ? new StudentFreeTextQuestionAnswer() : null,
                    AnswerAssessment = new QuestionAnswerAssessment
                    {
                        // TODO: do it in better way
                        AssessmentId = variant.TestSession.Assessment.Id,
                    },
                },
            }).ToList();
        }
    }
}