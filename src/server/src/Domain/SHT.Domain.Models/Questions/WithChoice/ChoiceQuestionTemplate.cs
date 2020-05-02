using System;
using System.Collections.Generic;

namespace SHT.Domain.Models.Questions.WithChoice
{
    public class ChoiceQuestionTemplate : BaseEntity
    {
        public Guid QuestionTemplateId { get; set; }

        public string QuestionText { get; set; }

        public virtual IList<ChoiceQuestionTemplateOption> Options { get; set; } =
            new List<ChoiceQuestionTemplateOption>();
    }
}