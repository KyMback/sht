using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SHT.Api.Web.Attributes;
using SHT.Application.Common;
using SHT.Application.Tests.TestSessions.Create;
using SHT.Application.Tests.TestSessions.GetAvailableStateTransitions;
using SHT.Application.Tests.TestSessions.GetList;
using SHT.Application.Tests.TestSessions.StateTransition;
using SHT.Infrastructure.DataAccess.Abstractions;

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

        [AuthorizeInstructorsOnly]
        [HttpPost]
        public Task<CreatedEntityResponse> Create(CreateTestSessionDto data)
        {
            return _mediator.Send(new CreateTestSessionRequest(data));
        }

        [AuthorizeInstructorsOnly]
        [HttpGet("list")]
        public Task<SearchResult<TestSessionListItemDto>> GetList([FromQuery] SearchResultBaseFilter filter)
        {
            return _mediator.Send(new GetAllTestSessionsRequest(filter));
        }

        [AuthorizeInstructorsOnly]
        [HttpPut("state")]
        public Task StateTransition(TestSessionStateTransitionRequest request)
        {
            return _mediator.Send(request);
        }

        [AuthorizeInstructorsOnly]
        [HttpGet("state/{id}")]
        public Task<IReadOnlyCollection<string>> GetStateTransitions([FromRoute] Guid id)
        {
            return _mediator.Send(new GetTestSessionAvailableStateTransitionsRequest(id));
        }
    }
}