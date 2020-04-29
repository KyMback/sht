using System.Threading.Tasks;

namespace SHT.Domain.Services.Users
{
    public interface IUserEmailService
    {
        Task SendEmailConfirmationEmail(string email, string token);
    }
}