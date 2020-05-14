using System;
using System.Collections.Generic;
using System.Linq;
using SHT.Domain.Common.Core;
using SHT.Domain.Models.TestSessions.Students.Answers;

namespace SHT.Domain.Services.Student.Questions
{
    public class StudentQuestionAnswerQueryParameters : BaseQueryParameters<StudentQuestionAnswer>
    {
        public IReadOnlyCollection<Guid> TestSessionVariantQuestionIds { get; set; }

        public bool? IsAnswered { get; set; }

        protected override void AddFilters()
        {
            FilterIfHasValue(
                TestSessionVariantQuestionIds,
                answer => TestSessionVariantQuestionIds.Contains(answer.Question.QuestionId));
            FilterIfHasValue(IsAnswered, answer => answer.IsAnswered);
        }
    }
}