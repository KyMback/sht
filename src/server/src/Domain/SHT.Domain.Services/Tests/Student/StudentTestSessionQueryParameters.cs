using System;
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

        public string State { get; set; }

        public bool OrderDescByTestSessionCreatedAt { get; set; }

        protected override void AddFilters()
        {
            FilterIfHasValue(Id, session => session.Id == Id.Value);
            FilterIfHasValue(State, session => session.State == State);
            FilterIfHasValue(StudentId, session => session.StudentId == StudentId.Value);
        }

        protected override void AddSorting()
        {
            SortDescIf(OrderDescByTestSessionCreatedAt, session => session.TestSession.CreatedAt);
        }
    }
}