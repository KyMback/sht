using System.Threading.Tasks;
using SHT.Domain.Models.Tests.Students;

namespace SHT.Domain.Services.Student
{
    public interface IStudentTestSessionService
    {
        Task Start(StudentTestSession studentTestSession, string variant);
    }
}