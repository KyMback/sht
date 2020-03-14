using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SHT.Application.Users.Accounts.ConfirmEmail;
using SHT.Application.Users.Accounts.GetContext;
using SHT.Application.Users.Accounts.SignIn;
using SHT.Application.Users.Accounts.SignOut;
using SHT.Application.Users.Students.SignUp;

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
        [HttpPost("student/signUp")]
        public Task SignUpStudent(SignUpStudentDataDto commandStudentData)
        {
            return _mediator.Send(new SignUpStudentRequest(commandStudentData));
        }

        [AllowAnonymous]
        [HttpGet("signOut")]
        public Task SignOut()
        {
            return _mediator.Send(new SignOutRequest());
        }

        [AllowAnonymous]
        [HttpGet("confirm-email")]
        public Task ConfirmEmail([FromQuery] ConfirmEmailDataDto data)
        {
            return _mediator.Send(new ConfirmEmailRequest(data));
        }
    }
}