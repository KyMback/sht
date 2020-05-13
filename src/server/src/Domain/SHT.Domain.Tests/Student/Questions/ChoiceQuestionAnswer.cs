using System;
using System.Collections.Generic;

namespace SHT.Domain.Services.Student.Questions
{
    public class ChoiceQuestionAnswer
    {
        public IReadOnlyCollection<Guid> Answers { get; set; }
    }
}