using System.Threading.Tasks;

namespace SHT.Infrastructure.Services.Abstractions
{
    public interface IMailer
    {
        Task Send(MailData data);
    }
}