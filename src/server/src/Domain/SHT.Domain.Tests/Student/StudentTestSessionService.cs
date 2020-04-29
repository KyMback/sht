using System;
using System.Threading.Tasks;
using SHT.Domain.Common.Exceptions;
using SHT.Domain.Models.Tests.Students;
using SHT.Domain.Services.Tests.Student.Questions;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Domain.Services.Tests.Student
{
    internal class StudentTestSessionService : IStudentTestSessionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStudentQuestionService _studentQuestionService;

        public StudentTestSessionService(
            IUnitOfWork unitOfWork,
            IStudentQuestionService studentQuestionService)
        {
            _unitOfWork = unitOfWork;
            _studentQuestionService = studentQuestionService;
        }

        public async Task Start(StudentTestSession studentTestSession, string variant)
        {
            var queryParameters = new TestSessionVariantsQueryParameters
            {
                Name = variant,
                TestSessionId = studentTestSession.TestSessionId,
            };
            Guid? testVariantId =
                await _unitOfWork.GetSingleOrDefault(queryParameters, testVariant => (Guid?)testVariant.TestVariantId);

            if (!testVariantId.HasValue)
            {
                throw new CodedException(ErrorCode.InvalidVariantName);
            }

            studentTestSession.TestVariant = variant;
            await _studentQuestionService.AddQuestionsToStudentTestSession(new StudentQuestionCreationData
            {
                TestVariantId = testVariantId.Value,
                StudentTestSessionId = studentTestSession.Id,
            });
            await _unitOfWork.Update(studentTestSession);
        }
    }
}