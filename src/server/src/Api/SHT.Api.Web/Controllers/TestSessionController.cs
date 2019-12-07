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
using SHT.Application.Tests.TestSessions.GetList;
using SHT.Application.Tests.TestSessions.StateTransition;
using SHT.Infrastructure.DataAccess.Abstractions;

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
        public Task<CreatedEntityResponse> Create(CreateTestSessionDto data)
        {
            return _mediator.Send(new CreateTestSessionRequest(data));
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