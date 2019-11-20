using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SHT.Database.Defaults;
using SHT.Domain.Models.Users;

namespace SHT.Database.EF.Migrations.Seeds
{
    internal class UsersSeedsInitializer : ISeedsInitializer
    {
        private readonly IEnumerable<UserSeedData> _users = new[]
        {
            new UserSeedData
            {
                Id = UsersDefaults.Instructor.Id,
                Login = UsersDefaults.Instructor.Login,
                Password = UsersDefaults.DefaultPasswordHash,
                Type = UserType.Instructor,
            },
            new UserSeedData
            {
                Id = UsersDefaults.Student.Id,
                Login = UsersDefaults.Student.Login,
                Password = UsersDefaults.DefaultPasswordHash,
                Type = UserType.Student,
            }
        };

        public async Task ApplyDevSeeds(DbContext context)
        {
            await context.AddRangeAsync(_users.Select(u => new User
            {
                Id = u.Id,
                Login = u.Login,
                Password = u.Password,
                UserType = u.Type,
            }));
        }
    }
}