using HotChocolate.Types;
using SHT.Application.Questions.Contracts;

namespace SHT.Api.Web.GraphQl.Queries.Types
{
    public class ChoiceQuestionDtoGraphType : ObjectType<ChoiceQuestionDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ChoiceQuestionDto> descriptor)
        {
            descriptor.Field(e => e.QuestionText).Type<NonNullType<StringType>>();
            descriptor.Field(e => e.Options)
                .Type<NonNullType<ListType<NonNullType<ChoiceQuestionOptionDtoGraphType>>>>();
        }
    }
}