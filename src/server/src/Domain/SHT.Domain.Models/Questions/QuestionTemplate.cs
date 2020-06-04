using System;
using System.Collections.Generic;
using SHT.Domain.Models.Common;
using SHT.Domain.Models.Questions.WithChoice;
using SHT.Domain.Models.Tests;
using SHT.Domain.Models.Users;

namespace SHT.Domain.Models.Questions
{
    public class QuestionTemplate : BaseEntity, IHasCreatedBy, IHasCreatedAt, IHasModifiedAt
    {
        public string Name { get; set; }

        public QuestionType Type { get; set; }

        public Guid CreatedById { get; set; }

        public virtual Instructor CreatedBy { get; set; }

        public virtual FreeTextQuestionTemplate FreeTextQuestionTemplate { get; set; }

        public virtual ChoiceQuestionTemplate ChoiceQuestionTemplate { get; set; }

        public virtual IList<QuestionTemplateTag> Tags { get; set; } = new List<QuestionTemplateTag>();

        public virtual IList<QuestionTemplateImage> Images { get; set; } = new List<QuestionTemplateImage>();

        public bool IsShareable { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedAt { get; set; }
    }
}