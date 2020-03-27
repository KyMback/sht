using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SHT.Api.Web.Attributes;
using SHT.Application.Tests.StudentQuestions.Answer;

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

        [HttpPut("answer")]
        public Task Answer(AnswerStudentQuestionDto data)
        {
            return _mediator.Send(new AnswerStudentQuestionRequest(data));
        }
    }
}