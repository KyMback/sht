using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SHT.Api.Web.Attributes;
using SHT.Application.Common;
using SHT.Application.Common.Tables;
using SHT.Application.Tests.TestSessions.Contracts;
using SHT.Application.Tests.TestSessions.Create;
using SHT.Application.Tests.TestSessions.Get;
using SHT.Application.Tests.TestSessions.GetAvailableStateTransitions;
using SHT.Application.Tests.TestSessions.GetDetails;
using SHT.Application.Tests.TestSessions.GetList;
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
        public Task Update(TestSessionDetailsDto data, [FromRoute] Guid id)
        {
            return _mediator.Send(new UpdateTestSessionRequest(data, id));
        }

        [HttpGet("details/{id}")]
        public Task<TestSessionDetailsDto> GetDetails([FromRoute] Guid id)
        {
            return _mediator.Send(new GetTestSessionDetailsRequest(id));
        }

        [HttpGet("list")]
        public Task<TableResult<TestSessionListItemDto>> GetList([FromQuery] SearchResultBaseFilter filter)
        {
            return _mediator.Send(new GetAllTestSessionsRequest(filter));
        }

        [HttpGet("{id}")]
        public Task<TestSessionDto> Get([FromRoute] Guid id)
        {
            return _mediator.Send(new GetTestSessionRequest(id));
        }

        [HttpPut("state")]
        public Task StateTransition(TestSessionStateTransitionRequest request)
        {
            return _mediator.Send(request);
        }

        [HttpGet("state/{id}")]
        public Task<IReadOnlyCollection<string>> GetStateTransitions([FromRoute] Guid id)
        {
            return _mediator.Send(new GetTestSessionAvailableStateTransitionsRequest(id));
        }
    }
}