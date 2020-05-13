using System;
using SHT.Application.Common;

namespace SHT.Application.Tests.StudentQuestions.Contracts
{
    [ApiDataContract]
    public class AnswerStudentQuestionDto
    {
        public Guid QuestionId { get; set; }

        public FreeTextQuestionAnswerDto FreeTextAnswer { get; set; }

        public ChoiceQuestionAnswerDto ChoiceQuestionAnswer { get; set; }
    }
}