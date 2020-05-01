using HotChocolate.Types;
using SHT.Application.Questions.Contracts;

namespace SHT.Api.Web.GraphQl.Mutations.Types
{
    public class ChoiceQuestionDtoInputGraphType : InputObjectType<ChoiceQuestionDto>
    {
        protected override void Configure(IInputObjectTypeDescriptor<ChoiceQuestionDto> descriptor)
        {
            descriptor.Field(e => e.QuestionText).Type<NonNullType<StringType>>();
            descriptor.Field(e => e.Options)
                .Type<NonNullType<ListType<NonNullType<ChoiceQuestionOptionDtoInputGraphType>>>>();
        }
    }
}