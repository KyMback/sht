using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SHT.Api.Web.Attributes;
using SHT.Application.Common;
using SHT.Application.Common.Tables;
using SHT.Application.Tests.StudentsTestSessions.Get;
using SHT.Application.Tests.StudentsTestSessions.GetAll;
using SHT.Application.Tests.StudentsTestSessions.GetAvailableStateTransitions;
using SHT.Application.Tests.StudentsTestSessions.GetTestQuestions;
using SHT.Application.Tests.StudentsTestSessions.GetVariants;
using SHT.Application.Tests.StudentsTestSessions.StateTransition;

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
        public Task<TableResult<StudentTestSessionListItemDto>> GetAll([FromQuery] SearchResultBaseFilter data)
        {
            return _mediator.Send(new GetAllStudentTestSessionsRequest(data));
        }

        [HttpGet("{id}")]
        public Task<StudentTestSessionDto> Get([FromRoute] Guid id)
        {
            return _mediator.Send(new GetStudentTestSessionRequest(id));
        }

        [HttpGet("test-variants/{id}")]
        public Task<IEnumerable<string>> GetTestVariants([FromRoute] Guid id)
        {
            return _mediator.Send(new GetStudentTestSessionVariantsRequest(id));
        }

        [HttpGet("{id}/questions/list")]
        public Task<IReadOnlyCollection<StudentTestQuestionListItemDto>> GetTestQuestions([FromRoute] Guid id)
        {
            return _mediator.Send(new GetStudentTestQuestionsRequest(id));
        }
    }
}