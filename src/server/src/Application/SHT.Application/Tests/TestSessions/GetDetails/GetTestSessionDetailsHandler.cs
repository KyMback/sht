using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MediatR;
using SHT.Application.Tests.TestSessions.Contracts;
using SHT.Domain.Services.Tests;
using SHT.Infrastructure.Common;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Application.Tests.TestSessions.GetDetails
{
    [UsedImplicitly]
    internal class GetTestSessionDetailsHandler : IRequestHandler<GetTestSessionDetailsRequest, TestSessionDetailsDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IExecutionContextAccessor _executionContextAccessor;

        public GetTestSessionDetailsHandler(IUnitOfWork unitOfWork, IExecutionContextAccessor executionContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _executionContextAccessor = executionContextAccessor;
        }

        public Task<TestSessionDetailsDto> Handle(
            GetTestSessionDetailsRequest request,
            CancellationToken cancellationToken)
        {
            var queryParameters = new TestSessionQueryParameters
            {
                Id = request.Id,
                InstructorId = _executionContextAccessor.GetCurrentUserId(),
            };

            return _unitOfWork.GetSingle(queryParameters, session => new TestSessionDetailsDto
            {
                Name = session.Name,
                StudentsIds = session.StudentTestSessions.Select(e => e.StudentId).ToArray(),
                TestVariants = session.TestSessionTestVariants.Select(e => new TestSessionVariantDataDto
                {
                    Name = e.Name,
                    TestVariantId = e.TestVariantId,
                }).ToArray(),
            });
        }
    }
}