using System;
using SHT.Application.Common;
using SHT.Domain.Models.Tests;

namespace SHT.Application.Tests.TestSessions.Contracts.Edit
{
    [ApiDataContract]
    public class TestSessionVariantQuestionModificationData
    {
        public Guid? Id { get; set; }

        public int? Order { get; set; }

        public string Name { get; set; }

        public QuestionType Type { get; set; }

        public Guid? SourceQuestionId { get; set; }

        public TestSessionVariantFreeTextQuestionModificationData FreeTextQuestion { get; set; }

        public TestSessionVariantChoiceQuestionModificationData ChoiceQuestion { get; set; }
    }
}