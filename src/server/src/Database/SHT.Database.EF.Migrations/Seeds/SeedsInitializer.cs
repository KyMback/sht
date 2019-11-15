using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SHT.Database.EF.Migrations.Seeds
{
    public static class SeedsInitializer
    {
        private static readonly IReadOnlyCollection<ISeedsInitializer> Initializers = new[]
        {
            new UsersSeedsInitializer(),
        };

        public static async Task Initialize(DbContext context)
        {
            foreach (var seedsInitializer in Initializers)
            {
                await seedsInitializer.ApplyDevSeeds(context);
                await context.SaveChangesAsync();
            }
        }
    }
}