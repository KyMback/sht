using System;
using System.Collections.Generic;
using System.Linq;
using SHT.Domain.Common.Core;
using SHT.Domain.Models.TestSessions.Students;

namespace SHT.Domain.Services.Student
{
    public class StudentTestSessionQueryParameters : BaseQueryParameters<StudentTestSession>
    {
        public StudentTestSessionQueryParameters(Guid? id = default)
        {
            Id = id;
        }

        public Guid? Id { get; set; }

        public Guid? StudentId { get; set; }

        public Guid? TestSessionId { get; set; }

        public string State { get; set; }

        public IReadOnlyCollection<string> ExcludedStates { get; set; }

        public string ExceptTestSessionState { get; set; }

        public bool OrderDescByTestSessionCreatedAt { get; set; }

        public Guid? VariantId { get; set; }

        public IReadOnlyCollection<Guid> VariantIds { get; set; }

        protected override void AddFilters()
        {
            FilterIfHasValue(VariantIds, session => VariantIds.Contains(session.TestSessionId));
            FilterIfHasValue(VariantId, session => session.TestVariantId == VariantId.Value);
            FilterIfHasValue(Id, session => session.Id == Id.Value);
            FilterIfHasValue(State, session => session.State == State);
            FilterIfHasValue(StudentId, session => session.StudentId == StudentId.Value);
            FilterIfHasValue(ExceptTestSessionState, session => session.TestSession.State != ExceptTestSessionState);
            FilterIfHasValue(ExcludedStates, session => !ExcludedStates.Contains(session.State));
            FilterIfHasValue(TestSessionId, session => session.TestSessionId == TestSessionId.Value);
        }

        protected override void AddSorting()
        {
            SortDescIf(OrderDescByTestSessionCreatedAt, session => session.TestSession.CreatedAt);
        }
    }
}