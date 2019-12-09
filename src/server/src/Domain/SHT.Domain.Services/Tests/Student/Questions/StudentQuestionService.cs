using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SHT.Domain.Models.Tests;
using SHT.Domain.Models.Tests.Students;
using SHT.Domain.Services.Tests.Questions;
using SHT.Infrastructure.Common;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Domain.Services.Tests.Student.Questions
{
    internal class StudentQuestionService : IStudentQuestionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IExecutionContextAccessor _executionContextAccessor;

        public StudentQuestionService(IUnitOfWork unitOfWork, IExecutionContextAccessor executionContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _executionContextAccessor = executionContextAccessor;
        }

        public async Task AddQuestionsToStudentTestSession(StudentQuestionCreationData data)
        {
            var queryParameters = new QuestionQueryParameters
            {
                TestVariantId = data.TestVariantId,
            };

            IReadOnlyCollection<Question> questions = await _unitOfWork.GetAll(queryParameters);
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
            question.Answer = answer;
            await _unitOfWork.Update(question);
        }
    }
}