using HotChocolate.Types;
using SHT.Application.Tests.TestSessions.Contracts.Edit.Assessments;

namespace SHT.Api.Web.GraphQl.Mutations.Types.TestSession.Assessments
{
    public class AssessmentEditDtoInputGraphType : InputObjectType<AssessmentEditDto>
    {
        protected override void Configure(IInputObjectTypeDescriptor<AssessmentEditDto> descriptor)
        {
            descriptor.Field(e => e.Id);
            descriptor.Field(e => e.AssessmentQuestions)
                .Type<NonNullType<ListType<NonNullType<AnswersAssessmentQuestionEditDtoInputGraphType>>>>();
        }
    }
}