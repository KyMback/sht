using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MediatR;
using SHT.Application.Core;
using SHT.Common.Extensions;
using SHT.Domain.Services.Tests;
using SHT.Domain.Services.Tests.Student;
using SHT.Infrastructure.Common.Transactions;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Application.Tests.TestSessions.Create
{
    [UsedImplicitly]
    internal class CreateTestSessionHandler : IRequestHandler<CreateTestSessionRequest, CreatedEntityResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITestSessionService _testSessionService;
        private readonly IStudentTestSessionService _studentTestSessionService;

        public CreateTestSessionHandler(
            IUnitOfWork unitOfWork,
            ITestSessionService testSessionService,
            IStudentTestSessionService studentTestSessionService)
        {
            _unitOfWork = unitOfWork;
            _testSessionService = testSessionService;
            _studentTestSessionService = studentTestSessionService;
        }

        public async Task<CreatedEntityResponse> Handle(
            CreateTestSessionRequest request,
            CancellationToken cancellationToken)
        {
            CreateTestSessionDto data = request.Data;
            using var transaction = TransactionsFactory.Create();
            var created = await _testSessionService.CreateTestSession(new TestSessionCreationData
            {
                Name = data.Name,
                TestVariantsIds = data.TestVariantsIds,
            });
            await _unitOfWork.Commit();

            if (!data.StudentsIds.IsNullOrEmpty())
            {
                var studentSessionDataToSave = data.StudentsIds.Select(e =>
                    new StudentTestSessionCreationData
                    {
                        StudentId = e,
                        TestSessionId = created.Id,
                    }).ToArray();
                await _studentTestSessionService.Create(studentSessionDataToSave);
                await _unitOfWork.Commit();
            }

            transaction.Complete();

            return new CreatedEntityResponse(created.Id);
        }
    }
}