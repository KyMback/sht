using System;
using System.Threading.Tasks;

namespace SHT.Domain.Services.Student.Questions
{
    public interface IStudentQuestionService
    {
        Task Answer(Guid questionId, QuestionGenericAnswer answer);
    }
}