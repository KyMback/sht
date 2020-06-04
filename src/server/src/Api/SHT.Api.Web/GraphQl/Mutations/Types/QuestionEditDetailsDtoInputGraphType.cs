using HotChocolate.Types;
using SHT.Api.Web.GraphQl.Queries.Types;
using SHT.Application.Questions.Contracts;

namespace SHT.Api.Web.GraphQl.Mutations.Types
{
    public class QuestionEditDetailsDtoInputGraphType : InputObjectType<QuestionEditDetailsDto>
    {
        protected override void Configure(IInputObjectTypeDescriptor<QuestionEditDetailsDto> descriptor)
        {
            descriptor.Field(e => e.Name).Type<NonNullType<StringType>>();
            descriptor.Field(e => e.Type).Type<QuestionTypeGraphType>();
            descriptor.Field(e => e.FreeTextQuestionData).Type<FreeTextQuestionDtoInputGraphType>();
            descriptor.Field(e => e.ChoiceQuestionData).Type<ChoiceQuestionDtoInputGraphType>();
            descriptor.Field(e => e.Images).Type<ListType<NonNullType<UuidType>>>();
        }
    }
}