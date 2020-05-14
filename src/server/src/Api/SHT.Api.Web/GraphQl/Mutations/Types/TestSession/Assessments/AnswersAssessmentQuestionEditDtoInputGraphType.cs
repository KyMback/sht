using HotChocolate.Types;
using SHT.Application.Tests.TestSessions.Contracts.Edit.Assessments;

namespace SHT.Api.Web.GraphQl.Mutations.Types.TestSession.Assessments
{
    public class AnswersAssessmentQuestionEditDtoInputGraphType : InputObjectType<AnswersAssessmentQuestionEditDto>
    {
        protected override void Configure(IInputObjectTypeDescriptor<AnswersAssessmentQuestionEditDto> descriptor)
        {
            descriptor.Field(e => e.Id);
            descriptor.Field(e => e.QuestionText).Type<NonNullType<StringType>>();
            descriptor.Field(e => e.Questions).Type<NonNullType<ListType<NonNullType<UuidType>>>>();
        }
    }
}