using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MediatR;
using SHT.Application.StateMachineConfigs.Core;
using SHT.Domain.Models.Tests.Students;
using SHT.Domain.Services.Tests.Student;
using SHT.Infrastructure.Common;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Application.Tests.StudentsTestSessions.GetTriggers
{
    [UsedImplicitly]
    internal class GetStudentTestSessionTriggersHandler :
        IRequestHandler<GetStudentTestSessionTriggersRequest, IReadOnlyCollection<string>>
    {
        private readonly IExecutionContextAccessor _executionContextAccessor;
        private readonly IStateManager<StudentTestSession> _stateManager;
        private readonly IUnitOfWork _unitOfWork;

        public GetStudentTestSessionTriggersHandler(
            IExecutionContextAccessor executionContextAccessor,
            IStateManager<StudentTestSession> stateManager,
            IUnitOfWork unitOfWork)
        {
            _executionContextAccessor = executionContextAccessor;
            _stateManager = stateManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyCollection<string>> Handle(
            GetStudentTestSessionTriggersRequest request,
            CancellationToken cancellationToken)
        {
            var queryParameters = new StudentTestSessionQueryParameters(request.TestSessionId)
            {
                StudentId = _executionContextAccessor.GetCurrentUserId(),
            };
            var testSession = await _unitOfWork.GetSingle(queryParameters);
            return await _stateManager.GetAvailableTriggers(testSession);
        }
    }
}