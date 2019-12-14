using System;
using System.Linq;
using System.Threading.Tasks;
using SHT.Domain.Models.Tests.Students;
using SHT.Domain.Services.Tests.Variants;
using SHT.Infrastructure.Common;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Domain.Services.Tests.Student.Questions
{
    internal class StudentQuestionService : IStudentQuestionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IExecutionContextAccessor _executionContextAccessor;
        private readonly IStudentQuestionValidationService _studentQuestionValidationService;

        public StudentQuestionService(
            IUnitOfWork unitOfWork,
            IExecutionContextAccessor executionContextAccessor,
            IStudentQuestionValidationService studentQuestionValidationService)
        {
            _unitOfWork = unitOfWork;
            _executionContextAccessor = executionContextAccessor;
            _studentQuestionValidationService = studentQuestionValidationService;
        }

        public async Task AddQuestionsToStudentTestSession(StudentQuestionCreationData data)
        {
            var queryParameters = new TestVariantQuestionQueryParameters
            {
                TestVariantId = data.TestVariantId,
            };

            var questions =
                await _unitOfWork.GetAll(queryParameters, testVariantQuestion => testVariantQuestion);
            var studentQuestions = questions.Select(question => new StudentQuestion
            {
                Number = question.Number,
                Text = question.Text,
                Type = question.Type,
                StudentTestSessionId = data.StudentTestSessionId,
            }).ToArray();
            await _unitOfWork.AddRange(studentQuestions);
        }

        public async Task Answer(Guid questionId, string answer)
        {
            var queryParameters = new StudentQuestionQueryParameters
            {
                StudentId = _executionContextAccessor.GetCurrentUserId(),
                IsReadOnly = false,
                Id = questionId,
            };
            var question = await _unitOfWork.GetSingle(queryParameters);
            await _studentQuestionValidationService.ThrowIfTestSessionIsEnded(question.StudentTestSessionId);
            question.Answer = answer;
            await _unitOfWork.Update(question);
        }
    }
}