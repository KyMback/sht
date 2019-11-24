using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SHT.Domain.Models.Tests;
using SHT.Domain.Models.Tests.Students;
using SHT.Domain.Services.Tests.Questions;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Domain.Services.Tests.Student.Questions
{
    internal class StudentQuestionService : IStudentQuestionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentQuestionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddQuestionsToStudentTestSession(
            StudentQuestionCreationData data)
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
                State = StudentQuestionState.Pending,
            }).ToArray();
            await _unitOfWork.AddRange(studentQuestions);
        }
    }
}