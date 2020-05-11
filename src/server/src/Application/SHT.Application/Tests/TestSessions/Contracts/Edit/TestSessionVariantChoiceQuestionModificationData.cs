using System.Collections.Generic;
using SHT.Application.Common;

namespace SHT.Application.Tests.TestSessions.Contracts.Edit
{
    [ApiDataContract]
    public class TestSessionVariantChoiceQuestionModificationData
    {
        public string QuestionText { get; set; }

        public IReadOnlyCollection<TestSessionVariantChoiceQuestionOptionModificationData> Options { get; set; }
    }
}