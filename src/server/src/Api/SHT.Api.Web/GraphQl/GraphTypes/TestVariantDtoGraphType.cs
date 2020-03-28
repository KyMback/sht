using HotChocolate.Types;
using SHT.Application.TestVariants.Contracts;

namespace SHT.Api.Web.GraphQl.GraphTypes
{
    public class TestVariantDtoGraphType : ObjectType<TestVariantDto>
    {
        protected override void Configure(IObjectTypeDescriptor<TestVariantDto> descriptor)
        {
            descriptor.Field(e => e.Id);
            descriptor.Field(e => e.Name).Type<NonNullType<StringType>>();
            descriptor.Field(e => e.CreatedByName).Type<NonNullType<StringType>>();
            descriptor.Field(e => e.Questions)
                .Type<NonNullType<ListType<NonNullType<TestVariantQuestionDtoGraphType>>>>();
        }
    }
}