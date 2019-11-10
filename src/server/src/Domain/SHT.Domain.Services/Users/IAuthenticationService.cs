using System.Threading.Tasks;

namespace SHT.Domain.Services.Users
{
    public interface IAuthenticationService
    {
        Task SignIn(LoginData data);

        Task SignOut();

        Task SignUp(RegistrationData data);
    }
}