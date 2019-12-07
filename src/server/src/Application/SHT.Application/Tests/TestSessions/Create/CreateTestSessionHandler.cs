using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MediatR;
using SHT.Application.Common;
using SHT.Application.Tests.TestSessions.Contracts;
using SHT.Domain.Services.Tests;
using SHT.Infrastructure.Common.Transactions;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Application.Tests.TestSessions.Create
{
    [UsedImplicitly]
    internal class CreateTestSessionHandler : IRequestHandler<CreateTestSessionRequest, CreatedEntityResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITestSessionService _testSessionService;

        public CreateTestSessionHandler(
            IUnitOfWork unitOfWork,
            ITestSessionService testSessionService)
        {
            _unitOfWork = unitOfWork;
            _testSessionService = testSessionService;
        }

        public async Task<CreatedEntityResponse> Handle(
            CreateTestSessionRequest request,
            CancellationToken cancellationToken)
        {
            CreateTestSessionDto data = request.Data;
            using var transaction = TransactionsFactory.Create();

            var created = await _testSessionService.CreateTestSession(data.Name);
            await _unitOfWork.Commit();

            await _testSessionService.LinkStudents(new StudentTestSessionLinkData(created, data.StudentsIds));
            await _testSessionService.LinkVariants(new TestSessionVariantsLinkData(
                created,
                data.TestVariants.Select(e => new KeyValuePair<string, Guid>(e.Name, e.TestVariantId)).ToArray()));
            await _unitOfWork.Commit();

            transaction.Complete();

            return new CreatedEntityResponse(created.Id);
        }
    }
}