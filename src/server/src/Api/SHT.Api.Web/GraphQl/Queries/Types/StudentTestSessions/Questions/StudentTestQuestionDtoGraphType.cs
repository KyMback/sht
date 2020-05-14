using HotChocolate.Types;
using SHT.Api.Web.GraphQl.Queries.Types.TestSessions;
using SHT.Application.Tests.StudentQuestions.Contracts;

namespace SHT.Api.Web.GraphQl.Queries.Types.StudentTestSessions.Questions
{
    public class StudentTestQuestionDtoGraphType : ObjectType<StudentTestQuestionDto>
    {
        protected override void Configure(IObjectTypeDescriptor<StudentTestQuestionDto> descriptor)
        {
            descriptor.Field(e => e.Id);
            descriptor.Field(e => e.Answer).Type<NonNullType<StudentQuestionAnswerDtoGraphType>>();
            descriptor.Field(e => e.IsAnswered);
            descriptor.Field(e => e.Order);
            descriptor.Field(e => e.StudentTestSessionId);
            descriptor.Field(e => e.FreeTextQuestion).Type<TestSessionVariantFreeTextQuestionDtoGraphType>();
            descriptor.Field(e => e.ChoiceQuestion).Type<StudentChoiceQuestionDtoGraphType>();
            descriptor.Field(e => e.Type).Type<QuestionTypeGraphType>();
        }
    }
}