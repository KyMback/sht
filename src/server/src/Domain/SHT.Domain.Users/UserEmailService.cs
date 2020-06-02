using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using SHT.Infrastructure.Common.Options;
using SHT.Infrastructure.Common.Utils;
using SHT.Infrastructure.Services;

namespace SHT.Domain.Users
{
    internal class UserEmailService : IUserEmailService
    {
        private readonly IMailer _mailer;
        private readonly RoutesOptions _routesOptions;
        private readonly IStringLocalizer _stringLocalizer;

        public UserEmailService(IMailer mailer, RoutesOptions routesOptions, IStringLocalizer stringLocalizer)
        {
            _mailer = mailer;
            _routesOptions = routesOptions;
            _stringLocalizer = stringLocalizer;
        }

        public Task SendEmailConfirmationEmail(string email, string token)
        {
            var link = UriUtils.AddQueryArguments(
                _routesOptions.EmailConfirmationUri.ToString(),
                ("email", email),
                ("token", token));

            return _mailer.Send(new MailData
            {
                To = email,
                Subject = _stringLocalizer["ConfirmEmail_Subject"],
                Body = _stringLocalizer["ConfirmEmail_BodyTemplate", link],
            });
        }
    }
}