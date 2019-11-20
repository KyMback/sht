using System;
using SHT.Domain.Models.Tests;
using SHT.Domain.Services.Common;

namespace SHT.Domain.Services.Tests
{
    public class TestSessionQueryParameters : BaseQueryParameters<TestSession>
    {
        public TestSessionQueryParameters(Guid? id)
        {
            Id = id;
        }

        public Guid? Id { get; set; }

        protected override void AddFilters()
        {
            FilterIfHasValue(Id, session => session.Id == Id.Value);
        }
    }
}