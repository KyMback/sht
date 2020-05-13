using HotChocolate.Types;
using SHT.Application.Tests.StudentQuestions.Contracts;

namespace SHT.Api.Web.GraphQl.Mutations.Types
{
    public class AnswerStudentQuestionDtoInputGraphType : InputObjectType<AnswerStudentQuestionDto>
    {
        protected override void Configure(IInputObjectTypeDescriptor<AnswerStudentQuestionDto> descriptor)
        {
            descriptor.Field(e => e.FreeTextAnswer).Type<FreeTextQuestionAnswerDtoInputGraphType>();
            descriptor.Field(e => e.ChoiceQuestionAnswer).Type<ChoiceQuestionAnswerDtoInputGraphType>();
            descriptor.Field(e => e.QuestionId);
        }
    }
}