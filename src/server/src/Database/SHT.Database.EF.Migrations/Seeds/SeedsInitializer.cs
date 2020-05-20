using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SHT.Database.EF.Migrations.Seeds.Core;

namespace SHT.Database.EF.Migrations.Seeds
{
    public static class SeedsInitializer
    {
        private static readonly IReadOnlyCollection<ISeedsInitializer> Initializers = new ISeedsInitializer[]
        {
            new OrganizationsSeedsInitializer(),
            new UsersSeedsInitializer(),
        };

        public static async Task InitializeSeeds(DbContext context)
        {
            foreach (var seedsInitializer in Initializers)
            {
                await seedsInitializer.ApplySeeds(context);
                await context.SaveChangesAsync();
            }
        }
    }
}