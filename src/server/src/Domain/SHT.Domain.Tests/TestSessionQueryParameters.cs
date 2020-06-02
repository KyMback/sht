using System;
using SHT.Domain.Common.Core;
using SHT.Domain.Models.TestSessions;
using SHT.Domain.Models.TestSessions.Variants;

namespace SHT.Domain.Services
{
    public class TestSessionQueryParameters : BaseQueryParameters<TestSession>
    {
        public TestSessionQueryParameters(Guid? id = default)
        {
            Id = id;
        }

        public Guid? Id { get; set; }

        public string State { get; set; }

        public bool DescByCreatedAt { get; set; }

        public Guid? InstructorId { get; set; }

        public bool IncludeStudentTestSessions { get; set; }

        public bool IncludeAssessment { get; set; }

        public bool IncludeAnswersAssessmentQuestions { get; set; }

        public bool IncludeVariants { get; set; }

        public bool IncludeVariantsQuestions { get; set; }

        protected override void AddFilters()
        {
            FilterIfHasValue(Id, session => session.Id == Id.Value);
            FilterIfHasValue(State, session => session.State == State);
            FilterIfHasValue(InstructorId, session => session.InstructorId == InstructorId.Value);
        }

        protected override void AddSorting()
        {
            SortDescIf(DescByCreatedAt, session => session.CreatedAt);
        }

        protected override void AddIncluded()
        {
            IncludeIf(IncludeStudentTestSessions, session => session.StudentTestSessions);
            IncludeIf(IncludeAssessment, session => session.Assessment);
            IncludeIf(IncludeAnswersAssessmentQuestions, session => session.Assessment.AnswersAssessmentQuestions);
            IncludeIf(IncludeVariants, session => session.Variants);
            If(IncludeVariantsQuestions, () => Include(e => e.Variants).ThenInclude(e => ((TestSessionVariant)e).Questions));
        }
    }
}