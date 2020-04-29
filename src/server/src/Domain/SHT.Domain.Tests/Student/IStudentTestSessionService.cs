using System.Threading.Tasks;
using SHT.Domain.Models.Tests.Students;

namespace SHT.Domain.Services.Tests.Student
{
    public interface IStudentTestSessionService
    {
        Task Start(StudentTestSession studentTestSession, string variant);
    }
}