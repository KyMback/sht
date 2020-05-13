using HotChocolate.Types;
using SHT.Application.Tests.StudentQuestions.Contracts;

namespace SHT.Api.Web.GraphQl.Queries.Types.StudentTestSessions.Questions
{
    public class StudentChoiceQuestionDtoGraphType : ObjectType<StudentChoiceQuestionDto>
    {
        protected override void Configure(IObjectTypeDescriptor<StudentChoiceQuestionDto> descriptor)
        {
            descriptor.Field(e => e.Id);
            descriptor.Field(e => e.QuestionText).Type<NonNullType<StringType>>();
            descriptor.Field(e => e.Options)
                .Type<NonNullType<ListType<NonNullType<StudentChoiceQuestionOptionDtoGraphType>>>>();
        }
    }
}