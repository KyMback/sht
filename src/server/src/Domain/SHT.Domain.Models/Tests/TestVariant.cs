using System;
using System.Collections.Generic;
using SHT.Domain.Models.Common;
using SHT.Domain.Models.Users;

namespace SHT.Domain.Models.Tests
{
    public class TestVariant : BaseEntity, IHasCreatedBy
    {
        public string Name { get; set; }

        public virtual IList<TestVariantQuestion> Questions { get; set; } = new List<TestVariantQuestion>();

        public Guid CreatedById { get; set; }

        public virtual Instructor CreatedBy { get; set; }
    }
}