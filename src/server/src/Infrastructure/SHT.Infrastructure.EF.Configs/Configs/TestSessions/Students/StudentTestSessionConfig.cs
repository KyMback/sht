using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHT.Domain.Models.TestSessions.Students;
using SHT.Domain.Models.TestSessions.Variants;
using SHT.Domain.Models.Users;
using SHT.Infrastructure.EF.Configs.Extensions;

namespace SHT.Infrastructure.EF.Configs.Configs.TestSessions.Students
{
    [UsedImplicitly]
    internal class StudentTestSessionConfig : BaseEntityConfig<StudentTestSession>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<StudentTestSession> builder)
        {
            builder.Property(e => e.State).HasMediumMaxLength().IsRequired();
            builder.Property(e => e.TestVariant).HasMediumMaxLength();

            builder
                .HasOne<Student>()
                .WithMany()
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder
                .HasMany(e => e.Questions)
                .WithOne(e => e.StudentTestSession)
                .HasForeignKey(e => e.StudentTestSessionId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne<TestSessionVariant>()
                .WithMany()
                .HasForeignKey(e => e.SourceTestVariantId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}