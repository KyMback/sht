using System.Collections.Generic;
using System.Threading.Tasks;
using SHT.Domain.Models.Tests.Students;

namespace SHT.Domain.Services.Tests.Student
{
    public interface IStudentTestSessionService
    {
        Task<IReadOnlyCollection<StudentTestSession>> Create(params StudentTestSessionCreationData[] sessions);

        Task Start(StudentTestSession studentTestSession, string variant);
    }
}