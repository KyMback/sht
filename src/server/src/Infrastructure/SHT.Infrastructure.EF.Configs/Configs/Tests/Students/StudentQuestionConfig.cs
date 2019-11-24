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
            builder.Property(e => e.Text).HasMaxLength(LengthConstants.LargeLength).IsRequired();
            builder.Property(e => e.Answer).HasMaxLength(LengthConstants.LargeLength);
            builder.Property(e => e.State).HasMaxLength(LengthConstants.MediumLength).IsRequired();
            builder.HasOne<StudentTestSession>().WithMany(e => e.Questions).HasForeignKey(e => e.StudentTestSessionId);
        }
    }
}