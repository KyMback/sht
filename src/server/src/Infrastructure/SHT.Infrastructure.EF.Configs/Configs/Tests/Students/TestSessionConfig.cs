using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHT.Domain.Models.Tests;
using SHT.Domain.Models.Users;

namespace SHT.Infrastructure.EF.Configs.Configs.Tests.Students
{
    [UsedImplicitly]
    internal class TestSessionConfig : BaseEntityConfig<TestSession>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<TestSession> builder)
        {
            builder.Property(e => e.State).HasMaxLength(LengthConstants.Medium).IsRequired();
            builder.Property(e => e.Name).HasMaxLength(LengthConstants.Medium).IsRequired();
            builder.HasOne<Instructor>().WithMany().HasForeignKey(e => e.InstructorId);
        }
    }
}