using System;
using System.Collections.Generic;
using SHT.Application.Common;

namespace SHT.Application.Tests.StudentQuestions.Contracts
{
    [ApiDataContract]
    public class ChoiceQuestionAnswerDto
    {
        public IReadOnlyCollection<Guid> Answers { get; set; }
    }
}