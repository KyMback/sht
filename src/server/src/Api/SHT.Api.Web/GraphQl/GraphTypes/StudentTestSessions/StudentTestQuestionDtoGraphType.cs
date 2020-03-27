using HotChocolate.Types;
using SHT.Application.Tests.StudentQuestions.Contracts;

namespace SHT.Api.Web.GraphQl.GraphTypes.StudentTestSessions
{
    public class StudentTestQuestionDtoGraphType : ObjectType<StudentTestQuestionDto>
    {
        protected override void Configure(IObjectTypeDescriptor<StudentTestQuestionDto> descriptor)
        {
            descriptor.Field(e => e.Id);
            descriptor.Field(e => e.Text).Type<NonNullType<StringType>>();
            descriptor.Field(e => e.Number).Type<NonNullType<StringType>>();
            descriptor.Field(e => e.Answer).Type<StringType>();
            descriptor.Field(e => e.IsAnswered);
            descriptor.Field(e => e.Type).Type<QuestionTypeGraphType>();
        }
    }
}