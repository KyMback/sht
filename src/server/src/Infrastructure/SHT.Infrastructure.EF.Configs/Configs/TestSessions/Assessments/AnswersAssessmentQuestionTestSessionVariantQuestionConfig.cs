using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHT.Domain.Models.TestSessions.Assessments;
using SHT.Domain.Models.TestSessions.Variants.Questions;

namespace SHT.Infrastructure.EF.Configs.Configs.TestSessions.Assessments
{
    [UsedImplicitly]
    internal class AnswersAssessmentQuestionTestSessionVariantQuestionConfig :
        BaseModelConfig<AnswersAssessmentQuestionTestSessionVariantQuestion>
    {
        public override void Configure(EntityTypeBuilder<AnswersAssessmentQuestionTestSessionVariantQuestion> builder)
        {
            builder.ToTable("AnswersAssessmentQuestion_TestSessionVariantQuestion");

            builder.HasKey(e => new
            {
                e.AnswersAssessmentQuestionId,
                e.TestSessionVariantQuestionId,
            });

            builder.HasOne(e => e.TestSessionVariantQuestion)
                .WithMany()
                .HasForeignKey(e => e.TestSessionVariantQuestionId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne<AnswersAssessmentQuestion>()
                .WithMany(e => e.Questions)
                .HasForeignKey(e => e.AnswersAssessmentQuestionId)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}