using System;
using SHT.Domain.Models.Users;
using SHT.Domain.Services.Common;

namespace SHT.Domain.Services.Users.Accounts
{
    public class AccountQueryParameters : BaseQueryParameters<Account>
    {
        public AccountQueryParameters(Guid? id = default, string email = default, string normalizedEmail = default)
        {
            Id = id;
            Email = email;
            NormalizedEmail = normalizedEmail;
        }

        public Guid? Id { get; set; }

        public string Email { get; set; }

        public string NormalizedEmail { get; set; }

        protected override void AddFilters()
        {
            FilterIfHasValue(Id, account => account.Id == Id.Value);
            FilterIfHasValue(Email, account => account.Email == Email);
#pragma warning disable CA1304 // Specify CultureInfo
            FilterIfHasValue(NormalizedEmail, account => account.Email.ToUpper() == NormalizedEmail.ToUpperInvariant());
#pragma warning restore CA1304 // Specify CultureInfo
        }
    }
}