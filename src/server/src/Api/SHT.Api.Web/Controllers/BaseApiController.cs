using Microsoft.AspNetCore.Mvc;
using SHT.Api.Web.Attributes;

namespace SHT.Api.Web.Controllers
{
    [ApiRoute]
    [ApiController]
    [Produces("application/json")]
    public class BaseApiController : ControllerBase
    {
    }
}