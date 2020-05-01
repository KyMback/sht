using HotChocolate.Types;
using SHT.Application.Questions.Contracts;

namespace SHT.Api.Web.GraphQl.Mutations.Types
{
    public class FreeTextQuestionDtoInputGraphType : InputObjectType<FreeTextQuestionDto>
    {
        protected override void Configure(IInputObjectTypeDescriptor<FreeTextQuestionDto> descriptor)
        {
            descriptor.Field(e => e.Question).Type<NonNullType<StringType>>();
        }
    }
}