using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHT.Domain.Models.TestSessions.Students;
using SHT.Domain.Models.TestSessions.Students.Answers;
using SHT.Infrastructure.EF.Configs.Extensions;

namespace SHT.Infrastructure.EF.Configs.Configs.TestSessions.Students
{
    public class StudentTestSessionQuestionConfig : BaseEntityConfig<StudentTestSessionQuestion>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<StudentTestSessionQuestion> builder)
        {
            builder.Property(e => e.Name).HasMediumMaxLength();

            builder
                .HasOne(e => e.Answer)
                .WithOne(e => e.Question)
                .HasForeignKey<StudentQuestionAnswer>(e => e.QuestionId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(e => e.Question)
                .WithMany()
                .HasForeignKey(e => e.QuestionId)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}