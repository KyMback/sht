using System.Threading.Tasks;

namespace SHT.Domain.Users
{
    public interface IUserEmailService
    {
        Task SendEmailConfirmationEmail(string email, string token);
    }
}