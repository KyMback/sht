using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MediatR;
using SHT.Application.StateMachineConfigs.Core;
using SHT.Domain.Models.Tests;
using SHT.Domain.Services.Tests;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Application.Tests.TestSessions.GetAvailableStateTransitions
{
    [UsedImplicitly]
    internal class GetTestSessionAvailableStateTransitionsHandler : IRequestHandler<
        GetTestSessionAvailableStateTransitionsRequest, IReadOnlyCollection<string>>
    {
        private readonly IStateManager<TestSession> _stateManager;
        private readonly IUnitOfWork _unitOfWork;

        public GetTestSessionAvailableStateTransitionsHandler(
            IStateManager<TestSession> stateManager,
            IUnitOfWork unitOfWork)
        {
            _stateManager = stateManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyCollection<string>> Handle(
            GetTestSessionAvailableStateTransitionsRequest request,
            CancellationToken cancellationToken)
        {
            var queryParameters = new TestSessionQueryParameters(request.Id);
            TestSession testSession = await _unitOfWork.GetSingle(queryParameters);
            var data = await _stateManager.GetAvailableTriggers(testSession);
            return data;
        }
    }
}