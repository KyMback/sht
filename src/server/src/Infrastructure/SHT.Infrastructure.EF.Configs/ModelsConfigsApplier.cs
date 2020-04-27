using Microsoft.EntityFrameworkCore;
using SHT.Infrastructure.EF.Configs.Extensions;

namespace SHT.Infrastructure.EF.Configs
{
    public static class ModelsConfigsApplier
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder
                .UseDefaultDeleteBehavior(DeleteBehavior.Restrict)
                .ApplyConfigurationsFromAssembly(typeof(BaseModelConfig<>).Assembly);
        }
    }
}