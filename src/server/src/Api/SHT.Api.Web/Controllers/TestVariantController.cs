using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SHT.Api.Web.Attributes;
using SHT.Application.Common;
using SHT.Application.Tests.Variants.GetLookups;

namespace SHT.Api.Web.Controllers
{
    [AuthorizeInstructorsOnly]
    [ApiRoute("test-variant")]
    public class TestVariantController : BaseApiController
    {
        private readonly IMediator _mediator;

        public TestVariantController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("lookups")]
        public Task<IReadOnlyCollection<Lookup>> GetLookups()
        {
            return _mediator.Send(new GetVariantsLookupsRequest());
        }
    }
}