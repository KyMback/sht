using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SHT.Domain.Models.Tests.Students;
using SHT.Domain.Services.Exceptions;
using SHT.Domain.Services.Users;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Domain.Services.Tests.Student
{
    internal class StudentTestSessionService : IStudentTestSessionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly StudentTestSessionCanBeCreatedForStudentsOnly _canBeCreatedForStudentsOnly;

        public StudentTestSessionService(
            IUnitOfWork unitOfWork,
            StudentTestSessionCanBeCreatedForStudentsOnly canBeCreatedForStudentsOnly)
        {
            _unitOfWork = unitOfWork;
            _canBeCreatedForStudentsOnly = canBeCreatedForStudentsOnly;
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
    }
}