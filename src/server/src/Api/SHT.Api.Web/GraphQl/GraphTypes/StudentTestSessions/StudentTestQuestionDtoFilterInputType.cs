using HotChocolate.Types.Filters;
using SHT.Application.Tests.StudentQuestions.Contracts;

namespace SHT.Api.Web.GraphQl.GraphTypes.StudentTestSessions
{
    public class StudentTestQuestionDtoFilterInputType : FilterInputType<StudentTestQuestionDto>
    {
        protected override void Configure(IFilterInputTypeDescriptor<StudentTestQuestionDto> descriptor)
        {
            descriptor.Filter(e => e.Id).AllowEquals();
            descriptor.Filter(e => e.StudentTestSessionId).AllowEquals();
        }
    }
}