using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SHT.Api.Web.Attributes;
using SHT.Application.Common;
using SHT.Application.Common.Tables;
using SHT.Application.Tests.TestSessions.Students.GetAll;
using SHT.Application.Tests.TestSessions.Students.GetAvailableStateTransitions;
using SHT.Application.Tests.TestSessions.Students.StateTransition;

namespace SHT.Api.Web.Controllers
{
    [AuthorizeStudentsOnly]
    [ApiRoute("student-test-session")]
    public class StudentTestSessionController : BaseApiController
    {
        private readonly IMediator _mediator;

        public StudentTestSessionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut("state")]
        public Task StateTransition(StudentTestSessionStateTransitionRequest request)
        {
            return _mediator.Send(request);
        }

        [HttpGet("state/{id}")]
        public Task<IEnumerable<string>> GetStateTransitions([FromRoute] Guid id)
        {
            return _mediator.Send(new GetStudentTestSessionAvailableStateTransitionsRequest(id));
        }

        [HttpGet("list")]
        public Task<TableResult<StudentTestSessionDto>> GetAll([FromQuery] SearchResultBaseFilter data)
        {
            return _mediator.Send(new GetAllStudentTestSessionsRequest(data));
        }
    }
}