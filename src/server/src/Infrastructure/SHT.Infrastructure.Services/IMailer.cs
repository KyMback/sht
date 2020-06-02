using System.Threading.Tasks;

namespace SHT.Infrastructure.Services
{
    public interface IMailer
    {
        Task Send(MailData data);
    }
}