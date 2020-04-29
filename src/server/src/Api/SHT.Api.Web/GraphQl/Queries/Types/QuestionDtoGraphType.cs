using HotChocolate.Types;
using SHT.Application.Questions.Contracts;

namespace SHT.Api.Web.GraphQl.Queries.Types
{
    public class QuestionDtoGraphType : ObjectType<QuestionDto>
    {
        protected override void Configure(IObjectTypeDescriptor<QuestionDto> descriptor)
        {
            descriptor.Field(e => e.Id);
            descriptor.Field(e => e.Name).Type<NonNullType<StringType>>();
            descriptor.Field(e => e.Text).Type<NonNullType<StringType>>();
            descriptor.Field(e => e.Type).Type<QuestionTypeGraphType>();
            descriptor.Field(e => e.CreatedById);
        }
    }
}