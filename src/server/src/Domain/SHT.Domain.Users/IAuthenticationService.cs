using System.Threading.Tasks;

namespace SHT.Domain.Users
{
    public interface IAuthenticationService
    {
        Task<bool> SignIn(LoginData data);

        Task SignOut();

        PasswordRules GetPasswordRules();
    }
}