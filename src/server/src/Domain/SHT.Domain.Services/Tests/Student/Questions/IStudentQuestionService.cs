using System.Threading.Tasks;

namespace SHT.Domain.Services.Tests.Student.Questions
{
    public interface IStudentQuestionService
    {
        Task AddQuestionsToStudentTestSession(StudentQuestionCreationData data);
    }
}