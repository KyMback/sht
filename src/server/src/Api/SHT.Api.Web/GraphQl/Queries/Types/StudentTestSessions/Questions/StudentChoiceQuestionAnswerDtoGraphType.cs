using HotChocolate.Types;
using SHT.Application.Tests.StudentQuestions.Contracts;

namespace SHT.Api.Web.GraphQl.Queries.Types.StudentTestSessions.Questions
{
    public class StudentChoiceQuestionAnswerDtoGraphType : ObjectType<StudentChoiceQuestionAnswerDto>
    {
        protected override void Configure(IObjectTypeDescriptor<StudentChoiceQuestionAnswerDto> descriptor)
        {
            descriptor.Field(e => e.OptionId);
        }
    }
}