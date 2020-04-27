using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MediatR;
using SHT.Application.StateMachineConfigs.Core;
using SHT.Domain.Models.Tests;
using SHT.Domain.Services.Tests;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Application.Tests.TestSessions.GetTriggers
{
    [UsedImplicitly]
    internal class GetTestSessionTriggersHandler :
        IRequestHandler<GetTestSessionTriggersRequest, IReadOnlyCollection<string>>
    {
        private readonly IStateManager<TestSession> _stateManager;
        private readonly IUnitOfWork _unitOfWork;

        public GetTestSessionTriggersHandler(IStateManager<TestSession> stateManager, IUnitOfWork unitOfWork)
        {
            _stateManager = stateManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyCollection<string>> Handle(
            GetTestSessionTriggersRequest request,
            CancellationToken cancellationToken)
        {
            var queryParameters = new TestSessionQueryParameters(request.TestSessionId);
            var testSession = await _unitOfWork.GetSingle(queryParameters);
            return await _stateManager.GetAvailableTriggers(testSession);
        }
    }
}