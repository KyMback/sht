using HotChocolate.Types;
using SHT.Api.Web.GraphQl.Extensions;
using SHT.Domain.Models.Tests;

namespace SHT.Api.Web.GraphQl.GraphTypes
{
    public class QuestionTypeGraphType : EnumType<QuestionType>
    {
        protected override void Configure(IEnumTypeDescriptor<QuestionType> descriptor)
        {
            descriptor.UseNamesAsValues();
        }
    }
}