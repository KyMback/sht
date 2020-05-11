using System;
using System.Collections.Generic;
using SHT.Domain.Models.TestSessions.Variants.Questions;

namespace SHT.Domain.Models.TestSessions.Variants
{
    public class TestSessionVariant : BaseEntity
    {
        public string Name { get; set; }

        public Guid TestSessionId { get; set; }

        public virtual TestSession TestSession { get; set; }

        public bool IsRandomOrder { get; set; }

        public virtual IList<TestSessionVariantQuestion> Questions { get; set; } =
            new List<TestSessionVariantQuestion>();
    }
}