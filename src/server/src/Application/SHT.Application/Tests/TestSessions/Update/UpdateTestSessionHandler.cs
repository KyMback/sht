using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using JetBrains.Annotations;
using MediatR;
using SHT.Domain.Models.TestSessions;
using SHT.Domain.Services;
using SHT.Infrastructure.Common.ExecutionContext;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Application.Tests.TestSessions.Update
{
    [UsedImplicitly]
    internal class UpdateTestSessionHandler : IRequestHandler<UpdateTestSessionRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITestSessionService _testSessionService;
        private readonly IExecutionContextService _executionContextService;
        private readonly IMapper _mapper;

        public UpdateTestSessionHandler(
            IUnitOfWork unitOfWork,
            ITestSessionService testSessionService,
            IExecutionContextService executionContextService,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _testSessionService = testSessionService;
            _executionContextService = executionContextService;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateTestSessionRequest request, CancellationToken cancellationToken)
        {
            var queryParameters = new TestSessionQueryParameters
            {
                Id = request.TestSessionId,
                InstructorId = _executionContextService.GetCurrentUserId(),
                IsReadOnly = false,
                IncludeStudentTestSessions = true,
                IncludeAssessment = true,
                IncludeVariants = true,
                IncludeVariantsQuestions = true,
                IncludeAnswersAssessmentQuestions = true,
            };
            TestSession testSession = await _unitOfWork.GetSingle(queryParameters);
            _mapper.Map(request.Data, testSession);
            await _testSessionService.Update(testSession);

            return default;
        }
    }
}