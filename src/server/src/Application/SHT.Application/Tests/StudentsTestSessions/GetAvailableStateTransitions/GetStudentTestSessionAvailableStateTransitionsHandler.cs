using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MediatR;
using SHT.Application.StateMachineConfigs.Core;
using SHT.Domain.Models.Tests.Students;
using SHT.Domain.Services.Tests.Student;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Application.Tests.StudentsTestSessions.GetAvailableStateTransitions
{
    [UsedImplicitly]
    internal class GetStudentTestSessionAvailableStateTransitionsHandler : IRequestHandler<
        GetStudentTestSessionAvailableStateTransitionsRequest, IEnumerable<string>>
    {
        private readonly IStateManager<StudentTestSession> _stateManager;
        private readonly IUnitOfWork _unitOfWork;

        public GetStudentTestSessionAvailableStateTransitionsHandler(
            IStateManager<StudentTestSession> stateManager,
            IUnitOfWork unitOfWork)
        {
            _stateManager = stateManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<string>> Handle(
            GetStudentTestSessionAvailableStateTransitionsRequest request,
            CancellationToken cancellationToken)
        {
            var queryParameters = new StudentTestSessionQueryParameters(request.Id);
            StudentTestSession session = await _unitOfWork.GetSingle(queryParameters);
            var data = await _stateManager.GetAvailableTriggers(session);
            return data;
        }
    }
}