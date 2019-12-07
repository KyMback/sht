using System.Threading.Tasks;
using SHT.Domain.Models.Tests;
using SHT.Domain.Services.Tests.Student;

namespace SHT.Domain.Services.Tests
{
    public interface ITestSessionService
    {
        Task<TestSession> CreateTestSession(string name);

        Task LinkStudents(StudentTestSessionLinkData linkData);

        Task LinkVariants(TestSessionVariantsLinkData linkData);
    }
}