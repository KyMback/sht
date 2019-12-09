using SHT.Application.Common;

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