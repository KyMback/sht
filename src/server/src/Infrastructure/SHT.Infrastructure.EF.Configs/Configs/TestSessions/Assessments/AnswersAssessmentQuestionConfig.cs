using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHT.Domain.Models.TestSessions.Assessments;
using SHT.Infrastructure.EF.Configs.Extensions;

namespace SHT.Infrastructure.EF.Configs.Configs.TestSessions.Assessments
{
    [UsedImplicitly]
    internal class AnswersAssessmentQuestionConfig : BaseEntityConfig<AnswersAssessmentQuestion>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<AnswersAssessmentQuestion> builder)
        {
            builder.Property(e => e.QuestionText).HasLargeMaxLength().IsRequired();

            builder
                .HasMany(e => e.AnswersRatings)
                .WithOne()
                .HasForeignKey(e => e.AnswersAssessmentQuestionId)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}