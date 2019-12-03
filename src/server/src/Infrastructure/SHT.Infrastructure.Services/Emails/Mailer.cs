using System.Net.Mail;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using SHT.Infrastructure.Services.Abstractions;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace SHT.Infrastructure.Services.Emails
{
    public class Mailer : IMailer
    {
        private readonly EmailOptions _emailOptions;

        public Mailer(IOptions<EmailOptions> emailOptions)
        {
            _emailOptions = emailOptions.Value;
        }

        public async Task Send(MailData data)
        {
            using var client = new SmtpClient();
            await client.ConnectAsync(_emailOptions.Host, _emailOptions.Port, true);

            if (client.Capabilities.HasFlag(SmtpCapabilities.Authentication))
            {
                await client.AuthenticateAsync(_emailOptions.Login, _emailOptions.Password);
            }

            await client.SendAsync(GetMessage(data));
            await client.DisconnectAsync(true);
        }

        private MimeMessage GetMessage(MailData data)
        {
            using var message = new MailMessage
            {
                From = new MailAddress(_emailOptions.FromAddress),
                To = { data.To },
                Subject = data.Subject,
                Body = data.Body,
            };

            return MimeMessage.CreateFromMailMessage(message);
        }
    }
}