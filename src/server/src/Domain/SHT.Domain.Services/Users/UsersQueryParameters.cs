using System;
using System.Collections.Generic;
using System.Linq;
using SHT.Domain.Models.Users;
using SHT.Domain.Services.Common;

namespace SHT.Domain.Services.Users
{
    public class UsersQueryParameters : BaseQueryParameters<User>
    {
        public UsersQueryParameters(Guid? id = default, string login = default, string normalizedUserName = default)
        {
            Id = id;
            Login = login;
            NormalizedLogin = normalizedUserName;
        }

        public Guid? Id { get; set; }

        public IEnumerable<Guid> Ids { get; set; }

        public string Login { get; set; }

        public string NormalizedLogin { get; set; }

        protected override void AddFilters()
        {
            FilterIfHasValue(Id, account => account.Id == Id.Value);
            FilterIfHasValue(Login, account => account.Login == Login);
#pragma warning disable CA1304 // Specify CultureInfo
            FilterIfHasValue(NormalizedLogin, account => account.Login.ToUpper() == NormalizedLogin);
#pragma warning restore CA1304 // Specify CultureInfo
            FilterIfHasValue(Ids, user => Ids.Contains(user.Id));
        }
    }
}