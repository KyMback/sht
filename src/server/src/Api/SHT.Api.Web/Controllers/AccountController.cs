using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SHT.Application.Users.Accounts.GetContext;
using SHT.Application.Users.Accounts.Register;
using SHT.Application.Users.Accounts.SignIn;
using SHT.Application.Users.Accounts.SignOut;

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
        [HttpPost("/signIn")]
        public Task SignIn(SignInDataDto data)
        {
            return _mediator.Send(SignInCommand.Command(data));
        }

        [AllowAnonymous]
        [HttpPost("/signUp")]
        public Task SignUp(RegistrationDataDto commandData)
        {
            return _mediator.Send(RegisterCommand.Command(commandData));
        }

        [AllowAnonymous]
        [HttpGet("/context")]
        public Task<UserContextDto> GetContext([FromQuery] Guid id)
        {
            return _mediator.Send(new GetContextQuery.Query
            {
                Id = id,
            });
        }

        [HttpGet("/signOut")]
        public Task SignOut()
        {
            return _mediator.Send(new SignOutCommand.Command());
        }
    }
}