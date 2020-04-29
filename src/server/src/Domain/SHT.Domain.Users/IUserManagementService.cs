using System.Threading.Tasks;
using SHT.Common;

namespace SHT.Domain.Services.Users
{
    public interface IUserManagementService<in TUser>
        where TUser : class
    {
        Task<CommonResult> Create(TUser user, string password);

        Task<CommonResult> UpdateUserTokens(TUser user);

        Task<bool> ValidateResetPasswordToken(TUser user, string token);

        Task<string> GenerateEmailConfirmToken(TUser user);

        Task<CommonResult> ConfirmEmail(TUser user, string token);
    }
}