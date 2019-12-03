using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SHT.Api.Web.Security.Constants;
using SHT.Domain.Services.Users;

namespace SHT.Api.Web.Security.Services
{
    internal class UserManagementService<TUser> : IUserManagementService<TUser>
        where TUser : class
    {
        private readonly UserManager<TUser> _userManager;
        private readonly EmailConfirmationTokenProvider<TUser> _emailConfirmationTokenProvider;

        public UserManagementService(
            UserManager<TUser> userManager,
            EmailConfirmationTokenProvider<TUser> emailConfirmationTokenProvider)
        {
            _userManager = userManager;
            _emailConfirmationTokenProvider = emailConfirmationTokenProvider;
        }

        public Task<bool> ValidateResetPasswordToken(TUser user, string token)
        {
            return _emailConfirmationTokenProvider.ValidateAsync(
                TokensDefaults.ConfirmEmail.Purpose,
                token,
                _userManager,
                user);
        }

        public Task<string> GenerateEmailConfirmToken(TUser user)
        {
            return _userManager.GenerateEmailConfirmationTokenAsync(user);
        }

        public async Task<UserOperationResult> ConfirmEmail(TUser user, string token)
        {
            var result = await _userManager.ConfirmEmailAsync(user, token);
            return new UserOperationResult
            {
                Succeeded = result.Succeeded,
                Errors = result.Errors.Select(e => e.Code).ToArray(),
            };
        }
    }
}