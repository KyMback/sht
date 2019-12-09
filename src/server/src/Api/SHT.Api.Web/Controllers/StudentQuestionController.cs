using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SHT.Api.Web.Attributes;
using SHT.Application.Tests.StudentQuestions.Get;

namespace SHT.Api.Web.Controllers
{
    [ApiRoute("student-question")]
    public class StudentQuestionController : BaseApiController
    {
        private readonly IMediator _mediator;

        public StudentQuestionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public Task<StudentQuestionDto> Get([FromRoute] Guid id)
        {
            return _mediator.Send(new GetStudentQuestionRequest(id));
        }
    }
}