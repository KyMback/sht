using System;
using SHT.Application.Common;

namespace SHT.Application.Tests.TestSessions.Contracts.Edit
{
    [ApiDataContract]
    public class TestSessionVariantChoiceQuestionOptionModificationData
    {
        public Guid? Id { get; set; }

        public string Text { get; set; }

        public bool IsCorrect { get; set; }
    }
}