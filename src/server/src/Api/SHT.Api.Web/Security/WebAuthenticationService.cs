using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SHT.Api.Web.Security.Constants;
using SHT.Domain.Models.Users;
using SHT.Domain.Services.Users;
using IAuthenticationService = SHT.Domain.Services.Users.IAuthenticationService;

namespace SHT.Api.Web.Security
{
    internal class WebAuthenticationService : IAuthenticationService
    {
        private readonly SignInManager<Account> _signInManager;
        private readonly UserManager<Account> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public WebAuthenticationService(
            SignInManager<Account> signInManager,
            UserManager<Account> userManager,
            IHttpContextAccessor httpContextAccessor)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> SignIn(LoginData data)
        {
            var result = await _signInManager.PasswordSignInAsync(data.Login, data.Password, true, false);
            return result.Succeeded;
        }

        public Task SignOut()
        {
            return _httpContextAccessor.HttpContext.SignOutAsync(AuthenticationDefaults.AuthenticationScheme);
        }

        public async Task<Account> SignUp(RegistrationData data)
        {
            var account = new Account
            {
                Email = data.Login,
            };
            var result = await _userManager.CreateAsync(account, data.Password);

            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.Aggregate(string.Empty, (s, error) => s + error.Description));
            }

            return account;
        }
    }
}