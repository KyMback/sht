using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using MoreLinq;
using SHT.Common.Utils;
using SHT.Domain.Models.Tests;
using SHT.Domain.Models.TestSessions.Students;
using SHT.Domain.Models.TestSessions.Students.Answers;
using SHT.Infrastructure.Common.ExecutionContext;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Domain.Services.Student.Questions
{
    internal class StudentQuestionService : IStudentQuestionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IExecutionContextService _executionContextService;
        private readonly IStudentQuestionValidationService _studentQuestionValidationService;

        public StudentQuestionService(
            IUnitOfWork unitOfWork,
            IExecutionContextService executionContextService,
            IStudentQuestionValidationService studentQuestionValidationService)
        {
            _unitOfWork = unitOfWork;
            _executionContextService = executionContextService;
            _studentQuestionValidationService = studentQuestionValidationService;
        }

        public async Task Answer(Guid questionId, QuestionGenericAnswer answer)
        {
            // TODO: add includes to optimize query
            var queryParameters = new StudentTestSessionQuestionQueryParameters
            {
                StudentId = _executionContextService.GetCurrentUserId(),
                IsReadOnly = false,
                Id = questionId,
            };
            StudentTestSessionQuestion question = await _unitOfWork.GetSingle(queryParameters);
            await _studentQuestionValidationService.ThrowIfCannotAnswer(question.StudentTestSessionId);

            SetAnswer(question, answer);

            await _unitOfWork.Update(question);
            await _unitOfWork.Commit();
        }

        private void SetAnswer(StudentTestSessionQuestion question, QuestionGenericAnswer answer)
        {
            switch (question.Question.Type)
            {
                case QuestionType.FreeText:
                    SetFreeTextAnswer(question, answer.FreeTextAnswer);
                    return;
                case QuestionType.QuestionWithChoice:
                    SetChoiceQuestionAnswer(question, answer.ChoiceQuestionAnswer);
                    return;
                default:
                    throw new InvalidEnumArgumentException(
                        nameof(question.Question.Type),
                        (int)question.Question.Type,
                        typeof(QuestionType));
            }
        }

        private void SetFreeTextAnswer(StudentTestSessionQuestion question, QuestionFreeTextAnswer answer)
        {
            Assert.NotNull(answer, nameof(answer));

            question.Answer.IsAnswered = true;
            question.Answer.FreeTextAnswer.Answer = answer.Answer;
        }

        private void SetChoiceQuestionAnswer(StudentTestSessionQuestion question, ChoiceQuestionAnswer answer)
        {
            Assert.NotNull(answer, nameof(answer));

            question.Answer.IsAnswered = true;
            question.Answer.ChoiceQuestionAnswers = answer.Answers.LeftJoin(
                    question.Answer.ChoiceQuestionAnswers,
                    source => source,
                    destination => destination.OptionId,
                    source => new StudentChoiceQuestionAnswer
                    {
                        OptionId = source,
                    }, (source, destination) => destination)
                .ToList();
        }
    }
}