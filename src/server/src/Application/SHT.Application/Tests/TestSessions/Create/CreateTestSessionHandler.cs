using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MediatR;
using SHT.Application.Core;
using SHT.Domain.Services.Tests;
using SHT.Infrastructure.Common;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Application.Tests.TestSessions.Create
{
    [UsedImplicitly]
    internal class CreateTestSessionHandler : IRequestHandler<CreateTestSessionRequest, CreatedEntityResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITestSessionService _testSessionService;
        private readonly IExecutionContextAccessor _executionContextAccessor;

        public CreateTestSessionHandler(
            IUnitOfWork unitOfWork,
            ITestSessionService testSessionService,
            IExecutionContextAccessor executionContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _testSessionService = testSessionService;
            _executionContextAccessor = executionContextAccessor;
        }

        public async Task<CreatedEntityResponse> Handle(
            CreateTestSessionRequest request,
            CancellationToken cancellationToken)
        {
            var data = request.Data;
            var created = await _testSessionService.CreateTestSession(new TestSessionCreationData
            {
                Name = data.Name,
                StudentsIds = data.StudentsIds,
                TestVariantsIds = data.TestVariantsIds,
                InstructorId = _executionContextAccessor.GetCurrentUserId(),
            });
            var added = await _unitOfWork.Add(created);
            await _unitOfWork.Commit();
            return new CreatedEntityResponse(added.Id);
        }
    }
}