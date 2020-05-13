using HotChocolate.Types;
using SHT.Application.Tests.StudentQuestions.Contracts;

namespace SHT.Api.Web.GraphQl.Mutations.Types
{
    public class FreeTextQuestionAnswerDtoInputGraphType : InputObjectType<FreeTextQuestionAnswerDto>
    {
        protected override void Configure(IInputObjectTypeDescriptor<FreeTextQuestionAnswerDto> descriptor)
        {
            descriptor.Field(e => e.Answer);
        }
    }
}