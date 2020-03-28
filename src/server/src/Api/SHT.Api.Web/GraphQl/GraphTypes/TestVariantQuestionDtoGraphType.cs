using HotChocolate.Types;
using SHT.Application.TestVariants.Contracts;

namespace SHT.Api.Web.GraphQl.GraphTypes
{
    public class TestVariantQuestionDtoGraphType : ObjectType<TestVariantQuestionDto>
    {
        protected override void Configure(IObjectTypeDescriptor<TestVariantQuestionDto> descriptor)
        {
            descriptor.Field(e => e.Id);
            descriptor.Field(e => e.Type).Type<QuestionTypeGraphType>();
            descriptor.Field(e => e.Number).Type<NonNullType<StringType>>();
            descriptor.Field(e => e.ShortQuestionLabel).Type<NonNullType<StringType>>();
        }
    }
}