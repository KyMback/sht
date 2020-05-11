using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using JetBrains.Annotations;
using MediatR;
using SHT.Application.Tests.TestSessions.Contracts.Edit;
using SHT.Domain.Models.Tests;
using SHT.Domain.Models.TestSessions;
using SHT.Domain.Services;
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
            var queryParameters = new TestSessionQueryParameters
            {
                Id = request.TestSessionId,
                InstructorId = _executionContextAccessor.GetCurrentUserId(),
                IsReadOnly = false,
            };
            TestSession testSession = await _unitOfWork.GetSingle(queryParameters);
            _mapper.Map(request.Data, testSession);
            await _testSessionService.Update(testSession);

            return default;
        }
    }
}