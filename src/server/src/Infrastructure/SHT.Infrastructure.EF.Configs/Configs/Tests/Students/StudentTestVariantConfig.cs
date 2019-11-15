using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHT.Domain.Models.Tests.Students;
using SHT.Domain.Models.Users;

namespace SHT.Infrastructure.EF.Configs.Configs.Tests.Students
{
    [UsedImplicitly]
    internal class StudentTestVariantConfig : BaseEntityConfig<StudentTestVariant>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<StudentTestVariant> builder)
        {
            builder.Property(e => e.State).HasMaxLength(LengthConstants.MediumLength).IsRequired();
            builder.HasOne<User>().WithMany().HasForeignKey(e => e.StudentId);
            builder.HasOne<TestSession>().WithMany().HasForeignKey(e => e.TestSessionId);
        }
    }
}