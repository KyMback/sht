using HotChocolate.Types;
using SHT.Application.Tests.StudentQuestions.Contracts;

namespace SHT.Api.Web.GraphQl.Queries.Types.StudentTestSessions.Questions
{
    public class StudentQuestionAnswerDtoGraphType : ObjectType<StudentQuestionAnswerDto>
    {
        protected override void Configure(IObjectTypeDescriptor<StudentQuestionAnswerDto> descriptor)
        {
            descriptor.Field(e => e.ChoiceQuestionAnswers)
                .Type<ListType<NonNullType<StudentChoiceQuestionAnswerDtoGraphType>>>();
            descriptor.Field(e => e.FreeTextAnswer).Type<StudentFreeTextQuestionAnswerDtoGraphType>();
        }
    }
}