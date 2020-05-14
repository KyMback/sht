using System.Threading.Tasks;
using SHT.Domain.Models.Tests;
using SHT.Domain.Models.TestSessions;

namespace SHT.Domain.Services
{
    public interface ITestSessionService
    {
        Task<TestSession> Create(TestSession testSession);

        Task<TestSession> Update(TestSession testSession);

        Task StartAssessmentPhase(TestSession testSession);
    }
}