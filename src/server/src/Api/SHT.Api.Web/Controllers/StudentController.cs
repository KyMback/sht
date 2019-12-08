using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SHT.Api.Web.Attributes;
using SHT.Application.Users.Students.GetGroups;

namespace SHT.Api.Web.Controllers
{
    [ApiRoute]
    public class StudentController : BaseApiController
    {
        private readonly IMediator _mediator;

        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("groups")]
        public Task<IReadOnlyCollection<StudentGroupedGroupDto>> GetStudentsGroups()
        {
            return _mediator.Send(new GetStudentsGroupedByGroupsRequest());
        }
    }
}