using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SHT.Domain.Models.Users;

namespace SHT.Database.EF.Migrations.Seeds
{
    internal class UsersSeedsInitializer : ISeedsInitializer
    {
        private readonly IEnumerable<UserSeedData> _users = new[]
        {
            new UserSeedData
            {
                Login = "test",

                // 123
                Password = "AQAAAAEAACcQAAAAEEmCXm5QMk27Fe2TKs2lH89f0Msfsh6hvwhpbjFX6fSHYnxs3l40FMOX53p5J4kK4A==",
                Type = UserType.Instructor,
            }
        };

        public async Task ApplyDevSeeds(DbContext context)
        {
            await context.AddRangeAsync(_users.Select(u => new User
            {
                Login = u.Login,
                Password = u.Password,
                UserType = u.Type,
            }));
        }
    }
}