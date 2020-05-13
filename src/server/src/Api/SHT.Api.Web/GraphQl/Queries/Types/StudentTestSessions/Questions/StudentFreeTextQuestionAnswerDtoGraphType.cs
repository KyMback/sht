using HotChocolate.Types;
using SHT.Application.Tests.StudentQuestions.Contracts;

namespace SHT.Api.Web.GraphQl.Queries.Types.StudentTestSessions.Questions
{
    public class StudentFreeTextQuestionAnswerDtoGraphType : ObjectType<StudentFreeTextQuestionAnswerDto>
    {
        protected override void Configure(IObjectTypeDescriptor<StudentFreeTextQuestionAnswerDto> descriptor)
        {
            descriptor.Field(e => e.Answer);
        }
    }
}