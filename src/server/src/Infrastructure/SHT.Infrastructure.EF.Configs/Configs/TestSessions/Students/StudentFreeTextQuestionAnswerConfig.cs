using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHT.Domain.Models.TestSessions.Students.Answers;
using SHT.Infrastructure.EF.Configs.Extensions;

namespace SHT.Infrastructure.EF.Configs.Configs.TestSessions.Students
{
    [UsedImplicitly]
    internal class StudentFreeTextQuestionAnswerConfig : BaseEntityConfig<StudentFreeTextQuestionAnswer>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<StudentFreeTextQuestionAnswer> builder)
        {
            builder.Property(e => e.Answer).HasLargeMaxLength();
        }
    }
}