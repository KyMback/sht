using System.Threading.Tasks;
using SHT.Domain.Models.Users;

namespace SHT.Domain.Services.Users
{
    public interface IUserAccountService
    {
        Task SendEmailConfirmation(Account account);

        Task ConfirmEmail(string email, string token);
    }
}