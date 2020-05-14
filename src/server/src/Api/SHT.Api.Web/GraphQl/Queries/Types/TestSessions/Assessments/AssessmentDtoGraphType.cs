using HotChocolate.Types;
using SHT.Application.Tests.TestSessions.Contracts.Assessments;

namespace SHT.Api.Web.GraphQl.Queries.Types.TestSessions.Assessments
{
    public class AssessmentDtoGraphType : ObjectType<AssessmentDto>
    {
        protected override void Configure(IObjectTypeDescriptor<AssessmentDto> descriptor)
        {
            descriptor.Field(e => e.Id);
            descriptor.Field(e => e.TestSessionId);
            descriptor.Field(e => e.AssessmentQuestions)
                .Type<NonNullType<ListType<NonNullType<AnswersAssessmentQuestionDtoGraphType>>>>();
        }
    }
}