using HotChocolate.Types;
using SHT.Application.Tests.TestSessions.Contracts.Assessments;

namespace SHT.Api.Web.GraphQl.Queries.Types.TestSessions.Assessments
{
    public class AnswersAssessmentQuestionDtoGraphType : ObjectType<AnswersAssessmentQuestionDto>
    {
        protected override void Configure(IObjectTypeDescriptor<AnswersAssessmentQuestionDto> descriptor)
        {
            descriptor.Field(e => e.Id);
            descriptor.Field(e => e.QuestionText).Type<NonNullType<StringType>>();
            descriptor.Field(e => e.Questions).Type<NonNullType<ListType<NonNullType<UuidType>>>>();
        }
    }
}