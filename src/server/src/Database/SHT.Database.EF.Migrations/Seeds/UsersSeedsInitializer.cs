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
        private static readonly IReadOnlyCollection<Instructor> Instructors = new[]
        {
            new Instructor
            {
                Id = UsersDefaults.Instructor.Id,
                Account = new Account
                {
                    Email = UsersDefaults.Instructor.Email,
                    Password = UsersDefaults.DefaultPasswordHash,
                    IsEmailConfirmed = true,
                    UserType = UserType.Instructor
                }
            },
        };

        public async Task ApplySeeds(DbContext context)
        {
            await context.AddRangeAsync(Instructors);
        }
    }
}