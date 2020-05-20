using System;
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
                    Id = UsersDefaults.Instructor.Id,
                    Email = UsersDefaults.Instructor.Email,
                    Password = UsersDefaults.DefaultPasswordHash,
                    IsEmailConfirmed = true,
                    UserType = UserType.Instructor,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    OrganizationId = OrganizationDefaults.DefaultOrganizationId,
                },
            },
        };

        private static readonly IReadOnlyCollection<Student> Students = new[]
        {
            new Student
            {
                Id = UsersDefaults.Student.Id,
                FirstName = UsersDefaults.Student.FirstName,
                LastName = UsersDefaults.Student.LastName,
                Group = UsersDefaults.Student.Group,
                Account = new Account
                {
                    Id = UsersDefaults.Student.Id,
                    Email = UsersDefaults.Student.Email,
                    Password = UsersDefaults.DefaultPasswordHash,
                    IsEmailConfirmed = true,
                    UserType = UserType.Student,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    OrganizationId = OrganizationDefaults.DefaultOrganizationId,
                }
            },
        };

        public async Task ApplySeeds(DbContext context)
        {
            await context.AddRangeAsync(Instructors);
            await context.AddRangeAsync(Students);
        }
    }
}