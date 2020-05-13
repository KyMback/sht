using SHT.Application.Common;

namespace SHT.Application.Tests.StudentQuestions.Contracts
{
    [ApiDataContract]
    public class FreeTextQuestionAnswerDto
    {
        public string Answer { get; set; }
    }
}