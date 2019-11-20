using System;
using SHT.Domain.Models.Users;

namespace SHT.Database.EF.Migrations.Seeds
{
    internal class UserSeedData
    {
        public Guid Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public UserType Type { get; set; }
    }
}