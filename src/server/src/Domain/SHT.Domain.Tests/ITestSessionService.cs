using System.Threading.Tasks;
using SHT.Domain.Models.Tests;

namespace SHT.Domain.Services
{
    public interface ITestSessionService
    {
        Task<TestSession> Create(TestSessionModificationData data);

        Task<TestSession> Update(TestSession original, TestSessionModificationData data);
    }
}