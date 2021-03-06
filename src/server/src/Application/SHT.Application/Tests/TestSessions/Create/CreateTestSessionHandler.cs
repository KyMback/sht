using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using JetBrains.Annotations;
using MediatR;
using SHT.Application.Common;
using SHT.Domain.Models.TestSessions;
using SHT.Domain.Services;

namespace SHT.Application.Tests.TestSessions.Create
{
    [UsedImplicitly]
    internal class CreateTestSessionHandler : IRequestHandler<CreateTestSessionRequest, CreatedEntityResponse>
    {
        private readonly ITestSessionService _testSessionService;
        private readonly IMapper _mapper;

        public CreateTestSessionHandler(
            ITestSessionService testSessionService,
            IMapper mapper)
        {
            _testSessionService = testSessionService;
            _mapper = mapper;
        }

        public async Task<CreatedEntityResponse> Handle(
            CreateTestSessionRequest request,
            CancellationToken cancellationToken)
        {
            var created = await _testSessionService.Create(_mapper.Map<TestSession>(request.Data));
            return new CreatedEntityResponse(created.Id);
        }
    }
}