using System;
using System.Collections.Generic;
using System.Linq;
using SHT.Domain.Models.Tests.Students;
using SHT.Domain.Services.Common;

namespace SHT.Domain.Services.Tests.Student
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

        protected override void AddFilters()
        {
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