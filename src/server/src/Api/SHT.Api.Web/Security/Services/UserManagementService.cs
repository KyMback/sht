using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SHT.Api.Web.Security.Constants;
using SHT.Common;
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

        public async Task<CommonResult> Create(TUser user, string password)
        {
            IdentityResult result = await _userManager.CreateAsync(user, password);
            return MapResults(result);
        }

        public async Task<CommonResult> UpdateUserTokens(TUser user)
        {
            IdentityResult result = await _userManager.UpdateSecurityStampAsync(user);
            return MapResults(result);
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

        public async Task<CommonResult> ConfirmEmail(TUser user, string token)
        {
            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (!result.Succeeded)
            {
                return MapResults(result);
            }

            return await UpdateUserTokens(user);
        }

        private CommonResult MapResults(IdentityResult result)
        {
            return new CommonResult(result.Succeeded, result.Errors?.Select(e => e.Code).ToArray());
        }
    }
}