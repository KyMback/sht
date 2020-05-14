using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHT.Domain.Models.TestSessions;
using SHT.Domain.Models.TestSessions.Assessments;
using SHT.Domain.Models.Users;
using SHT.Infrastructure.EF.Configs.Extensions;

namespace SHT.Infrastructure.EF.Configs.Configs.TestSessions
{
    [UsedImplicitly]
    internal class TestSessionConfig : BaseEntityConfig<TestSession>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<TestSession> builder)
        {
            builder.Property(e => e.State).HasMediumMaxLength().IsRequired();
            builder.Property(e => e.Name).HasMediumMaxLength().IsRequired();

            builder
                .HasOne<Instructor>()
                .WithMany()
                .HasForeignKey(e => e.InstructorId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder
                .HasMany(e => e.Variants)
                .WithOne(e => e.TestSession)
                .HasForeignKey(e => e.TestSessionId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder
                .HasMany(e => e.StudentTestSessions)
                .WithOne(e => e.TestSession)
                .HasForeignKey(e => e.TestSessionId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(e => e.Assessment)
                .WithOne(e => e.TestSession)
                .HasForeignKey<Assessment>(e => e.TestSessionId)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}