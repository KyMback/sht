using System;
using System.Threading.Tasks;
using SHT.Domain.Models.TestSessions.Students;

namespace SHT.Domain.Services.Student
{
    public interface IStudentTestSessionService
    {
        Task Start(StudentTestSession studentTestSession, Guid variantId);
    }
}