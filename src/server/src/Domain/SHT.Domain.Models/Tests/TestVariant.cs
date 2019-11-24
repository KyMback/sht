using System.Collections.Generic;

namespace SHT.Domain.Models.Tests
{
    public class TestVariant : BaseEntity
    {
        public string Name { get; set; }

        public virtual IList<TestSessionTestVariant> TestSessionTestVariants { get; set; }

        public virtual IList<Question> Questions { get; set; }
    }
}