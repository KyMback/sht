using System.Threading.Tasks;

namespace SHT.Domain.Services.Users
{
    public interface IAuthenticationService
    {
        Task<bool> SignIn(LoginData data);

        Task SignOut();

        PasswordRules GetPasswordRules();
    }
}