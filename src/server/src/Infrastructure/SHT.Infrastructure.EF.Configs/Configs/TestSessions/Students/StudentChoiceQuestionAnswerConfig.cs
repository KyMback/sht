using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHT.Domain.Models.TestSessions.Students.Answers;
using SHT.Domain.Models.TestSessions.Variants.Questions;

namespace SHT.Infrastructure.EF.Configs.Configs.TestSessions.Students
{
    [UsedImplicitly]
    internal class StudentChoiceQuestionAnswerConfig : BaseEntityConfig<StudentChoiceQuestionAnswer>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<StudentChoiceQuestionAnswer> builder)
        {
            builder.HasIndex(e => new
            {
                e.OptionId,
                e.StudentQuestionAnswerId,
            }).IsUnique();

            builder
                .HasOne<TestSessionVariantChoiceQuestionOption>()
                .WithMany()
                .HasForeignKey(e => e.OptionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}