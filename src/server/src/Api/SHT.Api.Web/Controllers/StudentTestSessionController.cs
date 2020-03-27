using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SHT.Api.Web.Attributes;
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
    }
}