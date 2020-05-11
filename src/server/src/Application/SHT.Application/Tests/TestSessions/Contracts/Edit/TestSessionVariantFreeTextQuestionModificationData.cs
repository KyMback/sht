using SHT.Application.Common;

namespace SHT.Application.Tests.TestSessions.Contracts.Edit
{
    [ApiDataContract]
    public class TestSessionVariantFreeTextQuestionModificationData
    {
        public string QuestionText { get; set; }
    }
}