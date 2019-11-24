using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SHT.Domain.Models.Tests.Students;
using SHT.Domain.Services.Exceptions;
using SHT.Domain.Services.Tests.Student.Questions;
using SHT.Domain.Services.Users;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Domain.Services.Tests.Student
{
    internal class StudentTestSessionService : IStudentTestSessionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly StudentTestSessionCanBeCreatedForStudentsOnly _canBeCreatedForStudentsOnly;
        private readonly IStudentQuestionService _studentQuestionService;

        public StudentTestSessionService(
            IUnitOfWork unitOfWork,
            StudentTestSessionCanBeCreatedForStudentsOnly canBeCreatedForStudentsOnly,
            IStudentQuestionService studentQuestionService)
        {
            _unitOfWork = unitOfWork;
            _canBeCreatedForStudentsOnly = canBeCreatedForStudentsOnly;
            _studentQuestionService = studentQuestionService;
        }

        public async Task<IReadOnlyCollection<StudentTestSession>> Create(
            params StudentTestSessionCreationData[] sessions)
        {
            var queryParameters = new UsersQueryParameters
            {
                Ids = sessions.Select(e => e.StudentId).ToArray(),
            };
            var users = await _unitOfWork.GetAll(queryParameters, user => user.UserType);

            if (!_canBeCreatedForStudentsOnly.Validate(users).IsValid)
            {
                throw new CodedException(ErrorCode.InvalidUserType);
            }

            var studentTestSessions = sessions.Select(e => new StudentTestSession
            {
                State = StudentTestSessionState.Pending,
                StudentId = e.StudentId,
                TestSessionId = e.TestSessionId,
            }).ToArray();

            await _unitOfWork.AddRange(studentTestSessions);

            return studentTestSessions;
        }

        public async Task Start(StudentTestSession studentTestSession, string variant)
        {
            var queryParameters = new TestVariantQueryParameters
            {
                Number = variant,
                TestSessionId = studentTestSession.TestSessionId,
            };
            Guid? testVariantId =
                await _unitOfWork.GetSingleOrDefault(queryParameters, testVariant => (Guid?)testVariant.Id);

            if (!testVariantId.HasValue)
            {
                throw new CodedException(ErrorCode.InvalidVariantName);
            }

            studentTestSession.TestNumber = variant;
            await _studentQuestionService.AddQuestionsToStudentTestSession(new StudentQuestionCreationData
            {
                TestVariantId = testVariantId.Value,
                StudentTestSessionId = studentTestSession.Id,
            });
            await _unitOfWork.Update(studentTestSession);
        }
    }
}