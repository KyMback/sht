using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MediatR;
using SHT.Application.Tests.TestSessions.Contracts;
using SHT.Domain.Models.Tests;
using SHT.Domain.Services.Tests;
using SHT.Infrastructure.Common;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Application.Tests.TestSessions.Update
{
    [UsedImplicitly]
    internal class UpdateTestSessionHandler : IRequestHandler<UpdateTestSessionRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITestSessionService _testSessionService;
        private readonly IExecutionContextAccessor _executionContextAccessor;

        public UpdateTestSessionHandler(
            IUnitOfWork unitOfWork,
            ITestSessionService testSessionService,
            IExecutionContextAccessor executionContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _testSessionService = testSessionService;
            _executionContextAccessor = executionContextAccessor;
        }

        public async Task<Unit> Handle(UpdateTestSessionRequest request, CancellationToken cancellationToken)
        {
            TestSessionDetailsDto data = request.Data;
            var queryParameters = new TestSessionQueryParameters
            {
                Id = request.Id,
                InstructorId = _executionContextAccessor.GetCurrentUserId(),
                IsReadOnly = false,
            };
            TestSession testSession = await _unitOfWork.GetSingle(queryParameters);
            await _testSessionService.LinkStudents(new StudentTestSessionLinkData(testSession, data.StudentsIds));
            await _testSessionService.LinkVariants(new TestSessionVariantsLinkData(
                testSession,
                data.TestVariants.Select(e => new KeyValuePair<string, Guid>(e.Name, e.TestVariantId)).ToArray()));
            await _unitOfWork.Commit();

            return Unit.Value;
        }
    }
}