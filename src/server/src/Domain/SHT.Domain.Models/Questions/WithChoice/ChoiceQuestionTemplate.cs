using System.Collections.Generic;

namespace SHT.Domain.Models.Questions.WithChoice
{
    public class ChoiceQuestionTemplate : BaseEntity
    {
        public string QuestionText { get; set; }

        public virtual IList<ChoiceQuestionTemplateOption> Options { get; set; } =
            new List<ChoiceQuestionTemplateOption>();
    }
}