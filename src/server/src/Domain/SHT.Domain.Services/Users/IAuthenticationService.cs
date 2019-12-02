using System.Threading.Tasks;
using SHT.Domain.Models.Users;

namespace SHT.Domain.Services.Users
{
    public interface IAuthenticationService
    {
        Task<bool> SignIn(LoginData data);

        Task SignOut();

        Task<Account> SignUp(RegistrationData data);
    }
}