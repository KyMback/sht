using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SHT.Application.Users.Accounts.GetContext;
using SHT.Application.Users.Accounts.SignIn;
using SHT.Application.Users.Accounts.SignOut;
using SHT.Application.Users.Accounts.SignUp;

namespace SHT.Api.Web.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost("signIn")]
        public Task<SignInResponse> SignIn(SignInDataDto data)
        {
            return _mediator.Send(new SignInRequest(data));
        }

        [AllowAnonymous]
        [HttpPost("signUp")]
        public Task SignUp(SignUpDataDto commandData)
        {
            return _mediator.Send(new SignUpRequest(commandData));
        }

        [AllowAnonymous]
        [HttpGet("context")]
        public Task<UserContextDto> GetContext()
        {
            return _mediator.Send(new GetContextRequest());
        }

        [HttpGet("signOut")]
        public Task SignOut()
        {
            return _mediator.Send(new SignOutRequest());
        }
    }
}