using System.Threading.Tasks;

namespace SHT.Domain.Services.Users
{
    public interface IUserManagementService<in TUser>
        where TUser : class
    {
        Task<bool> ValidateResetPasswordToken(TUser user, string token);

        Task<string> GenerateEmailConfirmToken(TUser user);

        Task<UserOperationResult> ConfirmEmail(TUser user, string token);
    }
}