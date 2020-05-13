using System;
using System.Linq;
using SHT.Domain.Common.Core;
using SHT.Domain.Models.TestSessions.Variants;

namespace SHT.Domain.Services
{
    public class TestSessionVariantsQueryParameters : BaseQueryParameters<TestSessionVariant>
    {
        public string Name { get; set; }

        public Guid? TestSessionId { get; set; }

        public Guid? StudentTestSessionId { get; set; }

        public Guid? StudentId { get; set; }

        public Guid? Id { get; set; }

        protected override void AddFilters()
        {
            FilterIfHasValue(
                StudentTestSessionId,
                variant => variant.TestSession.StudentTestSessions.Any(e => e.Id == StudentTestSessionId.Value));
            FilterIfHasValue(
                StudentId,
                variant => variant.TestSession.StudentTestSessions.Any(e => e.StudentId == StudentId.Value));
            FilterIfHasValue(Id, variant => variant.Id == Id.Value);
            FilterIfHasValue(Name, variant => variant.Name == Name);
            FilterIfHasValue(TestSessionId, variant => variant.TestSessionId == TestSessionId.Value);
        }
    }
}