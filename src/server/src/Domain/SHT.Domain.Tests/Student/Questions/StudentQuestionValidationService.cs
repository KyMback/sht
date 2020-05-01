using System;
using System.Threading.Tasks;
using SHT.Domain.Common.Exceptions;
using SHT.Domain.Models.Tests.Students;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Domain.Services.Student.Questions
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