using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SHT.Domain.Models.Users;
using SHT.Domain.Services.Users;

namespace SHT.Api.Web.Security
{
    internal class WebAuthenticationService : IAuthenticationService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public WebAuthenticationService(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public Task SignIn(LoginData data)
        {
            return _signInManager.PasswordSignInAsync(data.Login, data.Password, true, false);
        }

        public Task SignOut()
        {
            return _signInManager.SignOutAsync();
        }

        public async Task SignUp(RegistrationData data)
        {
            var result = await _userManager.CreateAsync(
                new User
                {
                    Login = data.Login,
                    UserType = data.UserType,
                }, data.Password);

            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.Aggregate(string.Empty, (s, error) => s + error.Description));
            }
        }
    }
}