using System;
using SHT.Domain.Models.Users;
using SHT.Domain.Services.Common;

namespace SHT.Domain.Services.Users
{
    public class UsersQueryParameters : BaseQueryParameters<User>
    {
        public UsersQueryParameters(Guid? id = default, string login = default)
        {
            Id = id;
            Login = login;
        }

        public Guid? Id { get; set; }

        public string Login { get; set; }

        protected override void AddFilters()
        {
            FilterIfHasValue(Id, account => account.Id == Id.Value);
            FilterIfHasValue(Login, account => account.Login == Login);
        }
    }
}