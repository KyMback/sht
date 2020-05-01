using HotChocolate.Types;
using SHT.Application.Questions.Contracts;

namespace SHT.Api.Web.GraphQl.Queries.Types
{
    public class FreeTextQuestionDtoGraphType : ObjectType<FreeTextQuestionDto>
    {
        protected override void Configure(IObjectTypeDescriptor<FreeTextQuestionDto> descriptor)
        {
            descriptor.Field(e => e.Question).Type<NonNullType<StringType>>();
        }
    }
}