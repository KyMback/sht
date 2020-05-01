using System.Threading.Tasks;
using SHT.Domain.Models.Users;

namespace SHT.Domain.Users.Accounts
{
    public interface IUserAccountService
    {
        Task<Account> Create(AccountCreationData data);

        Task SendEmailConfirmation(Account account);

        Task ConfirmEmail(string email, string token);
    }
}