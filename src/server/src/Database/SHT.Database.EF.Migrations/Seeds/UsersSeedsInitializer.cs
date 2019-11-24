using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SHT.Database.Defaults;
using SHT.Database.EF.Migrations.Seeds.Core;
using SHT.Domain.Models.Users;

namespace SHT.Database.EF.Migrations.Seeds
{
    internal class UsersSeedsInitializer : ISeedsInitializer
    {
        private static readonly IReadOnlyCollection<User> Users = new[]
        {
            new User
            {
                Id = UsersDefaults.Instructor.Id,
                Login = UsersDefaults.Instructor.Login,
                Password = UsersDefaults.DefaultPasswordHash,
                UserType = UserType.Instructor,
            },
            new User
            {
                Id = UsersDefaults.Student.Id,
                Login = UsersDefaults.Student.Login,
                Password = UsersDefaults.DefaultPasswordHash,
                UserType = UserType.Student,
            }
        };

        public async Task ApplySeeds(DbContext context)
        {
            await context.AddRangeAsync(Users);
        }
    }
}