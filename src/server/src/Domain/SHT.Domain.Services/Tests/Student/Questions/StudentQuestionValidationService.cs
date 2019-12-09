using System;
using System.Threading.Tasks;
using SHT.Domain.Models.Tests.Students;
using SHT.Domain.Services.Exceptions;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Domain.Services.Tests.Student.Questions
{
    internal class StudentQuestionValidationService : IStudentQuestionValidationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentQuestionValidationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task ThrowIfTestSessionIsEnded(Guid studentTestSessionId)
        {
            var queryParameters = new StudentTestSessionQueryParameters
            {
                Id = studentTestSessionId,
                ExcludedStates = new[] { StudentTestSessionState.Pending, StudentTestSessionState.Started },
            };

            if (await _unitOfWork.Any(queryParameters))
            {
                throw new CodedException(ErrorCode.StudentTestSessionEnded);
            }
        }
    }
}