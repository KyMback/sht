using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SHT.Api.Web.Attributes;

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
    }
}