using System;
using System.Threading.Tasks;

namespace SHT.Domain.Services.Student.Questions
{
    public interface IStudentQuestionValidationService
    {
        Task ThrowIfCannotAnswer(Guid studentTestSessionId);
    }
}