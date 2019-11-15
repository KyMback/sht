using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SHT.Api.Web.Attributes;
using SHT.Application.Core;
using SHT.Application.Tests.TestSessions.Create;

namespace SHT.Api.Web.Controllers
{
    [ApiRoute("test-session")]
    public class TestSessionController : BaseApiController
    {
        private readonly IMediator _mediator;

        public TestSessionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public Task<CreatedEntityResponse> Create(CreateTestSessionDto data)
        {
            return _mediator.Send(new CreateTestSessionRequest(data));
        }
    }
}