using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHT.Domain.Models.TestSessions.Students;
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

            builder
                .HasOne<Student>()
                .WithMany()
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(e => e.Questions)
                .WithOne(e => e.StudentTestSession)
                .HasForeignKey(e => e.StudentTestSessionId);

            builder
                .HasOne(e => e.Variant)
                .WithMany()
                .HasForeignKey(e => e.TestVariantId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}