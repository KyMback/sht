using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHT.Domain.Models.Tests.Students;
using SHT.Domain.Models.Users;

namespace SHT.Infrastructure.EF.Configs.Configs.Tests.Students
{
    [UsedImplicitly]
    internal class StudentTestSessionConfig : BaseEntityConfig<StudentTestSession>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<StudentTestSession> builder)
        {
            builder.Property(e => e.State).HasMaxLength(LengthConstants.Medium).IsRequired();
            builder.Property(e => e.TestVariant).HasMaxLength(LengthConstants.Medium);

            builder.HasOne<Student>().WithMany().HasForeignKey(e => e.StudentId);
            builder.HasOne(e => e.TestSession).WithMany(e => e.StudentTestSessions).HasForeignKey(e => e.TestSessionId);
        }
    }
}