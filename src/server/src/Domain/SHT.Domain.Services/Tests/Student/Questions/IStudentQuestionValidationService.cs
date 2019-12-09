using System;
using System.Threading.Tasks;

namespace SHT.Domain.Services.Tests.Student.Questions
{
    public interface IStudentQuestionValidationService
    {
        Task ThrowIfTestSessionIsEnded(Guid studentTestSessionId);
    }
}