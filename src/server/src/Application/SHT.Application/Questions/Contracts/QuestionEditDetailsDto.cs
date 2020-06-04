using System;
using System.Collections.Generic;
using SHT.Application.Common;
using SHT.Domain.Models.Tests;

namespace SHT.Application.Questions.Contracts
{
    [ApiDataContract]
    public class QuestionEditDetailsDto
    {
        public string Name { get; set; }

        public QuestionType Type { get; set; }

        public IReadOnlyCollection<Guid> Images { get; set; } = new List<Guid>();

        public FreeTextQuestionDto FreeTextQuestionData { get; set; }

        public ChoiceQuestionDto ChoiceQuestionData { get; set; }
    }
}