using HotChocolate.Types;
using SHT.Application.Questions.Contracts;

namespace SHT.Api.Web.GraphQl.Mutations.Types
{
    public class ChoiceQuestionOptionDtoInputGraphType : InputObjectType<ChoiceQuestionOptionDto>
    {
        protected override void Configure(IInputObjectTypeDescriptor<ChoiceQuestionOptionDto> descriptor)
        {
            descriptor.Field(e => e.Id).Type<UuidType>();
            descriptor.Field(e => e.Text).Type<NonNullType<StringType>>();
            descriptor.Field(e => e.IsCorrect);
        }
    }
}