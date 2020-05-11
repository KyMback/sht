using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MediatR;
using SHT.Domain.Services.Student;
using SHT.Infrastructure.Common;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Application.Tests.StudentsTestSessions.GetVariants
{
    [UsedImplicitly]
    internal class GetStudentTestSessionVariantsHandler :
        IRequestHandler<GetStudentTestSessionVariantsRequest, IReadOnlyCollection<string>>
    {
        private readonly IExecutionContextAccessor _executionContextAccessor;
        private readonly IUnitOfWork _unitOfWork;

        public GetStudentTestSessionVariantsHandler(IExecutionContextAccessor executionContextAccessor, IUnitOfWork unitOfWork)
        {
            _executionContextAccessor = executionContextAccessor;
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyCollection<string>> Handle(GetStudentTestSessionVariantsRequest request, CancellationToken cancellationToken)
        {
            var queryParameters = new StudentTestSessionQueryParameters
            {
                Id = request.StudentTestSessionId,
                StudentId = _executionContextAccessor.GetCurrentUserId(),
            };

            var result = await _unitOfWork.GetSingle(
                queryParameters,
                session => session.TestSession.Variants.Select(e => e.Name).ToArray());

            return result;
        }
    }
}