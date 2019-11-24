using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MediatR;
using SHT.Application.StateMachineConfigs.Core;
using SHT.Domain.Models.Tests.Students;
using SHT.Domain.Services.Tests.Student;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Application.Tests.TestSessions.Students.StateTransition
{
    [UsedImplicitly]
    internal class StudentTestSessionStateTransitionHandler : IRequestHandler<StudentTestSessionStateTransitionRequest>
    {
        private readonly IStateManager<StudentTestSession> _stateManager;
        private readonly IUnitOfWork _unitOfWork;

        public StudentTestSessionStateTransitionHandler(IStateManager<StudentTestSession> stateManager, IUnitOfWork unitOfWork)
        {
            _stateManager = stateManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(StudentTestSessionStateTransitionRequest request, CancellationToken cancellationToken)
        {
            var queryParameters = new StudentTestSessionQueryParameters(request.StudentTestSessionId)
            {
                IsReadOnly = false,
            };
            StudentTestSession session = await _unitOfWork.GetSingle(queryParameters);
            await _stateManager.Process(session, request.Trigger, request.SerializedData);
            await _unitOfWork.Update(session);
            await _unitOfWork.Commit();

            return Unit.Value;
        }
    }
}