using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHT.Domain.Models.Users;

namespace SHT.Infrastructure.EF.Configs.Configs
{
    [UsedImplicitly]
    internal class InstructorConfig : BaseEntityConfig<Instructor>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Instructor> builder)
        {
            builder.HasOne(e => e.Account).WithOne().HasForeignKey<Instructor>(e => e.Id);
        }
    }
}