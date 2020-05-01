using SHT.Application.Common;
using SHT.Domain.Models.Tests;

namespace SHT.Application.Questions.Contracts
{
    [ApiDataContract]
    public class QuestionEditDetailsDto
    {
        public string Name { get; set; }

        public QuestionType Type { get; set; }

        public FreeTextQuestionDto FreeTextQuestionData { get; set; }
    }
}