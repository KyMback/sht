using System;
using SHT.Domain.Models.Common;
using SHT.Domain.Models.Tests;

namespace SHT.Domain.Models.Questions
{
    public class QuestionTemplate : BaseEntity, IHasCreatedBy
    {
        public string Name { get; set; }

        public QuestionType Type { get; set; }

        public Guid CreatedById { get; set; }

        public virtual FreeTextQuestionTemplate FreeTextQuestionTemplate { get; set; }
    }
}