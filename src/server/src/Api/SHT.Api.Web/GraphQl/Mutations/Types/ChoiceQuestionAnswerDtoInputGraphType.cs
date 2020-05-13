using HotChocolate.Types;
using SHT.Application.Tests.StudentQuestions.Contracts;

namespace SHT.Api.Web.GraphQl.Mutations.Types
{
    public class ChoiceQuestionAnswerDtoInputGraphType : InputObjectType<ChoiceQuestionAnswerDto>
    {
        protected override void Configure(IInputObjectTypeDescriptor<ChoiceQuestionAnswerDto> descriptor)
        {
            descriptor.Field(e => e.Answers).Type<NonNullType<ListType<NonNullType<UuidType>>>>();
        }
    }
}