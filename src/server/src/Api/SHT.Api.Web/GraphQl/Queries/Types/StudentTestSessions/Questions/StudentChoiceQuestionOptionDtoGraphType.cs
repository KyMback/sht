using HotChocolate.Types;
using SHT.Application.Tests.StudentQuestions.Contracts;

namespace SHT.Api.Web.GraphQl.Queries.Types.StudentTestSessions.Questions
{
    public class StudentChoiceQuestionOptionDtoGraphType : ObjectType<StudentChoiceQuestionOptionDto>
    {
        protected override void Configure(IObjectTypeDescriptor<StudentChoiceQuestionOptionDto> descriptor)
        {
            descriptor.Field(e => e.Id);
            descriptor.Field(e => e.QuestionId);
            descriptor.Field(e => e.Text).Type<NonNullType<StringType>>();
        }
    }
}