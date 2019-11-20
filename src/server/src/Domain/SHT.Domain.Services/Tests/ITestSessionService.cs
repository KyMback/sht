using System.Threading.Tasks;
using SHT.Domain.Models.Tests;

namespace SHT.Domain.Services.Tests
{
    public interface ITestSessionService
    {
        Task<TestSession> CreateTestSession(TestSessionCreationData data);
    }
}