using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MediatR;
using SHT.Application.StateMachineConfigs.Core;
using SHT.Domain.Models.Tests;
using SHT.Domain.Services;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Application.Tests.TestSessions.StateTransition
{
    [UsedImplicitly]
    internal class TestSessionStateTransitionHandler : IRequestHandler<TestSessionStateTransitionRequest>
    {
        private readonly IStateManager<TestSession> _stateManager;
        private readonly IUnitOfWork _unitOfWork;

        public TestSessionStateTransitionHandler(IStateManager<TestSession> stateManager, IUnitOfWork unitOfWork)
        {
            _stateManager = stateManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(TestSessionStateTransitionRequest request, CancellationToken cancellationToken)
        {
            var queryParameters = new TestSessionQueryParameters(request.TestSessionId)
            {
                IsReadOnly = false,
            };
            var testSession = await _unitOfWork.GetSingle(queryParameters);
            await _stateManager.Process(testSession, request.Trigger);
            await _unitOfWork.Update(testSession);
            await _unitOfWork.Commit();

            return Unit.Value;
        }
    }
}