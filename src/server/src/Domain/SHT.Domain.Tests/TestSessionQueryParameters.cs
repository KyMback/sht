using System;
using SHT.Domain.Common.Core;
using SHT.Domain.Models.Tests;

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
    }
}