using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHT.Domain.Models.Tests.Students;
using SHT.Domain.Models.Users;

namespace SHT.Infrastructure.EF.Configs.Configs.Tests.Students
{
    [UsedImplicitly]
    internal class TestSessionConfig : BaseEntityConfig<TestSession>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<TestSession> builder)
        {
            builder.Property(e => e.State).HasMaxLength(LengthConstants.MediumLength).IsRequired();
            builder.Property(e => e.Name).HasMaxLength(LengthConstants.MediumLength).IsRequired();
            builder.HasOne<User>().WithMany().HasForeignKey(e => e.InstructorId);
        }
    }
}