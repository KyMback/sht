using HotChocolate.Types;
using SHT.Application.Tests.StudentQuestions.Answer;

namespace SHT.Api.Web.GraphQl.Mutations.Types
{
    public class AnswerStudentQuestionDtoInputGraphType : InputObjectType<AnswerStudentQuestionDto>
    {
        protected override void Configure(IInputObjectTypeDescriptor<AnswerStudentQuestionDto> descriptor)
        {
            descriptor.Field(e => e.Answer).Type<NonNullType<StringType>>();
            descriptor.Field(e => e.QuestionId);
        }
    }
}