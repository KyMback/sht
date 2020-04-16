using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SHT.Api.Web.Attributes;
using SHT.Application.Common;
using SHT.Application.Tests.TestSessions.Contracts;
using SHT.Application.Tests.TestSessions.Create;
using SHT.Application.Tests.TestSessions.StateTransition;
using SHT.Application.Tests.TestSessions.Update;

namespace SHT.Api.Web.Controllers
{
    [AuthorizeInstructorsOnly]
    [ApiRoute("test-session")]
    public class TestSessionController : BaseApiController
    {
        private readonly IMediator _mediator;

        public TestSessionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public Task<CreatedEntityResponse> Create(TestSessionDetailsDto data)
        {
            return _mediator.Send(new CreateTestSessionRequest(data));
        }

        [HttpPut("{id}")]
        public Task Update(TestSessionDetailsDto data)
        {
            return _mediator.Send(new UpdateTestSessionRequest(data));
        }

        [HttpPut("state")]
        public Task StateTransition(TestSessionStateTransitionRequest request)
        {
            return _mediator.Send(request);
        }
    }
}