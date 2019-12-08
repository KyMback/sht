using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHT.Domain.Models.Tests.Students;

namespace SHT.Infrastructure.EF.Configs.Configs.Tests.Students
{
    [UsedImplicitly]
    internal class StudentQuestionConfig : BaseEntityConfig<StudentQuestion>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<StudentQuestion> builder)
        {
            builder.Property(e => e.Text).HasMaxLength(LengthConstants.Large).IsRequired();
            builder.Property(e => e.Answer).HasMaxLength(LengthConstants.Large);
            builder.Property(e => e.Number).HasMaxLength(LengthConstants.Small).IsRequired();

            builder
                .HasOne(e => e.StudentTestSession)
                .WithMany(e => e.Questions)
                .HasForeignKey(e => e.StudentTestSessionId);
        }
    }
}