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
using SHT.Infrastructure.Common.StateMachine.Core;
using SHT.Infrastructure.Common.Transactions;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Domain.Services.Student
{
    internal class StudentTestSessionService : IStudentTestSessionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStateManager<StudentTestSession> _stateManager;

        public StudentTestSessionService(
            IUnitOfWork unitOfWork,
            IStateManager<StudentTestSession> stateManager)
        {
            _unitOfWork = unitOfWork;
            _stateManager = stateManager;
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
            var questions = variant.Questions.Select(e => new StudentTestSessionQuestion
            {
                QuestionId = e.Id,
                Order = e.Order ?? default,
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

            if (variant.IsRandomOrder)
            {
                var orderNumbers = RandomUtils.GenerateRandomSequence(1, questions.Count);
                for (int i = 0; i < orderNumbers.Count; i++)
                {
                    questions[i].Order = orderNumbers[i];
                }
            }

            return questions;
        }
    }
}