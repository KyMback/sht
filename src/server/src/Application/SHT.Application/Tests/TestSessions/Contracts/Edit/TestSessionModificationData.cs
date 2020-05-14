using System;
using System.Collections.Generic;
using SHT.Application.Common;
using SHT.Application.Tests.TestSessions.Contracts.Edit.Assessments;

namespace SHT.Application.Tests.TestSessions.Contracts.Edit
{
    [ApiDataContract]
    public class TestSessionModificationData
    {
        public Guid? Id { get; set; }

        public string Name { get; set; }

        public IReadOnlyCollection<Guid> StudentsIds { get; set; }

        public IReadOnlyCollection<TestSessionVariantModificationData> Variants { get; set; }

        public AssessmentEditDto Assessment { get; set; }
    }
}