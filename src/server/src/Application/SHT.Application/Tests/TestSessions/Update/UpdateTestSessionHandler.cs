using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using JetBrains.Annotations;
using MediatR;
using SHT.Domain.Models.Tests;
using SHT.Domain.Services.Tests;
using SHT.Infrastructure.Common;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Application.Tests.TestSessions.Update
{
    [UsedImplicitly]
    internal class UpdateTestSessionHandler : IRequestHandler<UpdateTestSessionRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITestSessionService _testSessionService;
        private readonly IExecutionContextAccessor _executionContextAccessor;
        private readonly IMapper _mapper;

        public UpdateTestSessionHandler(
            IUnitOfWork unitOfWork,
            ITestSessionService testSessionService,
            IExecutionContextAccessor executionContextAccessor,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _testSessionService = testSessionService;
            _executionContextAccessor = executionContextAccessor;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateTestSessionRequest request, CancellationToken cancellationToken)
        {
            var data = _mapper.Map<TestSessionModificationData>(request.Data);
            var queryParameters = new TestSessionQueryParameters
            {
                Id = request.TestSessionId,
                InstructorId = _executionContextAccessor.GetCurrentUserId(),
                IsReadOnly = false,
            };
            TestSession testSession = await _unitOfWork.GetSingle(queryParameters);
            await _testSessionService.Update(testSession, data);

            return default;
        }
    }
}