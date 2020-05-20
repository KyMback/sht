using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SHT.Database.Defaults;
using SHT.Database.EF.Migrations.Seeds.Core;
using SHT.Domain.Models;

namespace SHT.Database.EF.Migrations.Seeds
{
    internal class OrganizationsSeedsInitializer : ISeedsInitializer
    {
        public async Task ApplySeeds(DbContext context)
        {
            await context.AddAsync(new Organization
            {
                Id = OrganizationDefaults.DefaultOrganizationId,
                Name = OrganizationDefaults.DefaultOrganizationName,
            });
        }
    }
}