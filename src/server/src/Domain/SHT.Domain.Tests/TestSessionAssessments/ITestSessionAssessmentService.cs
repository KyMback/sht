using System.Threading.Tasks;
using SHT.Domain.Models.TestSessions.Assessments;

namespace SHT.Domain.Services.TestSessionAssessments
{
    public interface ITestSessionAssessmentService
    {
        Task CreateAssessmentQuestions(Assessment assessment);

        Task EvaluateAnswers(Assessment assessment);
    }
}