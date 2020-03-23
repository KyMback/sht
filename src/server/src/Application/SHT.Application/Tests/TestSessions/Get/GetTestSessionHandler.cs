using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MediatR;
using SHT.Application.Tests.TestSessions.Contracts;
using SHT.Domain.Services.Tests;
using SHT.Infrastructure.Common;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Application.Tests.TestSessions.Get
{
    [UsedImplicitly]
    internal class GetTestSessionHandler : IRequestHandler<GetTestSessionRequest, TestSessionDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IExecutionContextAccessor _executionContextAccessor;

        public GetTestSessionHandler(IUnitOfWork unitOfWork, IExecutionContextAccessor executionContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _executionContextAccessor = executionContextAccessor;
        }

        public Task<TestSessionDto> Handle(GetTestSessionRequest request, CancellationToken cancellationToken)
        {
            var queryParameters = new TestSessionQueryParameters(request.Data)
            {
                InstructorId = _executionContextAccessor.GetCurrentUserId(),
            };

            return _unitOfWork.GetSingle(queryParameters, session => new TestSessionDto
            {
                Id = session.Id,
                Name = session.Name,
                State = session.State,
                CreatedAt = session.CreatedAt,
            });
        }
    }
}