using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MediatR;
using SHT.Domain.Services.Tests.Student;
using SHT.Infrastructure.Common;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Application.Tests.StudentsTestSessions.GetVariants
{
    [UsedImplicitly]
    internal class GetStudentTestSessionVariantsHandler :
        IRequestHandler<GetStudentTestSessionVariantsRequest, IEnumerable<string>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IExecutionContextAccessor _executionContextAccessor;

        public GetStudentTestSessionVariantsHandler(
            IUnitOfWork unitOfWork,
            IExecutionContextAccessor executionContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _executionContextAccessor = executionContextAccessor;
        }

        public async Task<IEnumerable<string>> Handle(
            GetStudentTestSessionVariantsRequest request,
            CancellationToken cancellationToken)
        {
            var queryParameters = new StudentTestSessionQueryParameters
            {
                Id = request.Id,
                StudentId = _executionContextAccessor.GetCurrentUserId(),
            };

            var result = await _unitOfWork.GetSingle(
                queryParameters,
                session => session.TestSession.TestSessionTestVariants.Select(e => e.Name).ToArray());

            return result;
        }
    }
}