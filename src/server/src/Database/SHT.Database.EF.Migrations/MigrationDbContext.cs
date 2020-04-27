using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SHT.Infrastructure.EF.Configs;

namespace SHT.Database.EF.Migrations
{
    public class MigrationDbContext : DbContext, IDataProtectionKeyContext
    {
        public MigrationDbContext(DbContextOptions<MigrationDbContext> options)
            : base(options)
        {
        }

        public DbSet<DataProtectionKey> DataProtectionKeys { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ModelsConfigsApplier.Configure(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}