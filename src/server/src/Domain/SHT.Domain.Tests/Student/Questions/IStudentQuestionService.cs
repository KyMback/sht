using System;
using System.Threading.Tasks;

namespace SHT.Domain.Services.Student.Questions
{
    public interface IStudentQuestionService
    {
        Task AddQuestionsToStudentTestSession(StudentQuestionCreationData data);

        Task Answer(Guid questionId, string answer);
    }
}