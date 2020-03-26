using HotChocolate.Types;
using SHT.Application.Tests.StudentsTestSessions.Contracts;

namespace SHT.Api.Web.GraphQl.GraphTypes
{
    public class StudentTestQuestionListItemDtoGraphType : ObjectType<StudentTestQuestionListItemDto>
    {
        protected override void Configure(IObjectTypeDescriptor<StudentTestQuestionListItemDto> descriptor)
        {
            descriptor.Field(e => e.Id);
            descriptor.Field(e => e.Number).Type<NonNullType<StringType>>();
            descriptor.Field(e => e.IsAnswered);
            descriptor.Field(e => e.Type).Type<QuestionTypeGraphType>();
        }
    }
}