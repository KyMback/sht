using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHT.Domain.Models.Tests;
using SHT.Domain.Models.Tests.Students;
using SHT.Domain.Models.Users;

namespace SHT.Infrastructure.EF.Configs.Configs.Tests.Students
{
    [UsedImplicitly]
    internal class StudentTestSessionConfig : BaseEntityConfig<StudentTestSession>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<StudentTestSession> builder)
        {
            builder.Property(e => e.State).HasMaxLength(LengthConstants.MediumLength).IsRequired();
            builder.Property(e => e.TestNumber).HasMaxLength(LengthConstants.MediumLength);
            builder.HasOne<User>().WithMany().HasForeignKey(e => e.StudentId);
            builder.HasOne<TestSession>().WithMany(e => e.StudentTestSessions).HasForeignKey(e => e.TestSessionId);
        }
    }
}