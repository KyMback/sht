using System;
using SHT.Application.Common;

namespace SHT.Application.Tests.StudentQuestions.Answer
{
    [ApiDataContract]
    public class AnswerStudentQuestionDto
    {
        public Guid QuestionId { get; set; }

        public string Answer { get; set; }
    }
}