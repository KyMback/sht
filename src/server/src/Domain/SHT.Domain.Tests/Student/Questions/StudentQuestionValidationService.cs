using System;
using System.Threading.Tasks;
using SHT.Domain.Common.Exceptions;
using SHT.Domain.Models.TestSessions.Students;
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

        public async Task ThrowIfCannotAnswer(Guid studentTestSessionId)
        {
            var queryParameters = new StudentTestSessionQueryParameters
            {
                Id = studentTestSessionId,
                State = StudentTestSessionState.Started,
            };

            if (!await _unitOfWork.Any(queryParameters))
            {
                throw new CodedException(ErrorCode.StudentTestSessionEnded);
            }
        }
    }
}