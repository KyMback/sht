using HotChocolate.Types;
using SHT.Application.Questions.Contracts;

namespace SHT.Api.Web.GraphQl.Queries.Types
{
    public class ChoiceQuestionOptionDtoGraphType : ObjectType<ChoiceQuestionOptionDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ChoiceQuestionOptionDto> descriptor)
        {
            descriptor.Field(e => e.Id);
            descriptor.Field(e => e.Text).Type<NonNullType<StringType>>();
            descriptor.Field(e => e.IsCorrect);
        }
    }
}