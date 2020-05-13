using SHT.Application.Common;
using SHT.Application.Tests.StudentQuestions.Contracts;

namespace SHT.Application.Tests.StudentQuestions.Answer
{
    public class AnswerStudentQuestionRequest : BaseRequest<AnswerStudentQuestionDto>
    {
        public AnswerStudentQuestionRequest(AnswerStudentQuestionDto data)
            : base(data)
        {
        }
    }
}