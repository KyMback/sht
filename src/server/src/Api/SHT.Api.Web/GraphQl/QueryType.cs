using HotChocolate.Types;
using SHT.Api.Web.GraphQl.Extensions;
using SHT.Api.Web.GraphQl.GraphTypes;
using SHT.Api.Web.GraphQl.GraphTypes.StudentTestSessions;
using SHT.Api.Web.Security.Constants;
using SHT.Application.Tests.StudentQuestions.Contracts;
using SHT.Application.Tests.StudentsTestSessions.Contracts;
using SHT.Application.Tests.TestSessions.Contracts;
using SHT.Application.TestVariants.Contracts;

namespace SHT.Api.Web.GraphQl
{
    public class QueryType : ObjectType<GraphQueries>
    {
        protected override void Configure(IObjectTypeDescriptor<GraphQueries> descriptor)
        {
            descriptor
                .Field(f => f.GetUserContext(default, default))
                .Type<NonNullType<UserContextGraphType>>()
                .Name("userContext");

            descriptor
                .Field(f => f.GetTestSessionListItems(default, default))
                .Authorize(AuthorizationPolicyNames.InstructorsOnly)
                .Type<NonNullType<ListType<NonNullType<TestSessionListItemDtoGraphType>>>>()
                .Name("testSessionListItems")
                .UseOffsetBasedPaging<TestSessionListItemDtoGraphType, TestSessionListItemDto>()
                .UseCustomSelection<TestSessionListItemDto>()
                .UseSorting<TestSessionListItemDto>(typeDescriptor =>
                {
                    typeDescriptor.BindFieldsExplicitly();
                    typeDescriptor.Sortable(e => e.CreatedAt);
                });

            descriptor
                .Field(f => f.GetTestSessionDetails(default, default))
                .Authorize(AuthorizationPolicyNames.InstructorsOnly)
                .Type<TestSessionDetailsDtoGraphType>()
                .Name("testSessionDetails")
                .UseSingleOrDefault()
                // .UseSelection()
                // problem with second select for nested collections (mb issue with ef core)
                // see https://github.com/ChilliCream/hotchocolate/issues/1582
                // https://github.com/ChilliCream/hotchocolate/pull/1584
                .UseFiltering<TestSessionDetailsDto>(filterDescriptor =>
                    filterDescriptor.Filter(p => p.Id).AllowEquals());

            descriptor
                .Field(f => f.GetTestSessionTriggers(default, default, default))
                .Authorize(AuthorizationPolicyNames.InstructorsOnly)
                .Type<NonNullType<ListType<NonNullType<StringType>>>>()
                .Name("testSessionTriggers")
                .Argument("testSessionId", argumentDescriptor => argumentDescriptor.Type<NonNullType<UuidType>>());

            descriptor
                .Field(f => f.GetVariantsLookups(default, default))
                .Authorize(AuthorizationPolicyNames.InstructorsOnly)
                .Type<NonNullType<ListType<NonNullType<LookupGraphType>>>>()
                .Name("testVariantLookups")
                .UseSelection();

            descriptor
                .Field(f => f.GetStudentsGroups(default))
                .Authorize()
                .Type<NonNullType<ListType<NonNullType<StudentGroupedGroupDtoGraphType>>>>()
                .Name("studentsGroups");

            descriptor
                .Field(f => f.GetStudentsTestSessions(default, default))
                .Authorize(AuthorizationPolicyNames.StudentsOnly)
                .Type<NonNullType<ListType<NonNullType<StudentTestSessionDtoGraphType>>>>()
                .Name("studentTestSessions")
                .UseOffsetBasedPaging<StudentTestSessionDtoGraphType, StudentTestSessionDto>()
                .UseCustomSelection<StudentTestSessionDto>()
                .UseSorting<StudentTestSessionDto>(typeDescriptor =>
                {
                    typeDescriptor.BindFieldsExplicitly();
                    typeDescriptor.Sortable(e => e.CreatedAt);
                });

            descriptor
                .Field(f => f.GetStudentsTestSessions2(default, default))
                .Authorize(AuthorizationPolicyNames.StudentsOnly)
                .Type<StudentTestSessionDtoGraphType>()
                .Name("studentTestSession")
                .UseSingleOrDefault()
                .UseSelection()
                .UseFiltering<StudentTestSessionDto>(filterDescriptor =>
                    filterDescriptor.Filter(e => e.Id).AllowEquals());

            descriptor
                .Field(f => f.GetStudentTestSessionTriggers(default, default, default, default))
                .Authorize(AuthorizationPolicyNames.StudentsOnly)
                .Type<NonNullType<ListType<NonNullType<StringType>>>>()
                .Name("studentTestSessionTriggers")
                .Argument("testSessionId", argumentDescriptor => argumentDescriptor.Type<NonNullType<UuidType>>());

            descriptor
                .Field(f => f.GetStudentTestQuestions(default, default))
                .Authorize(AuthorizationPolicyNames.StudentsOnly)
                .Type<NonNullType<ListType<NonNullType<StudentTestQuestionDtoGraphType>>>>()
                .Name("studentTestQuestions")
                .UseSelection()
                .UseFiltering<StudentTestQuestionDtoFilterInputType>()
                .UseSorting<StudentTestQuestionDto>(sortDescriptor =>
                {
                    sortDescriptor.BindFieldsExplicitly();
                    sortDescriptor.Sortable(e => e.Number);
                });

            descriptor
                .Field(f => f.GetStudentTestQuestion(default, default))
                .Authorize(AuthorizationPolicyNames.StudentsOnly)
                .Type<StudentTestQuestionDtoGraphType>()
                .Name("studentTestQuestion")
                .UseSingleOrDefault()
                .UseSelection()
                .UseFiltering<StudentTestQuestionDtoFilterInputType>();

            descriptor
                .Field(f => f.GetStudentTestSessionVariants(default, default, default))
                .Authorize(AuthorizationPolicyNames.StudentsOnly)
                .Type<NonNullType<ListType<NonNullType<StringType>>>>()
                .Name("studentTestSessionVariants")
                .Argument("studentTestSessionId", argumentDescriptor => argumentDescriptor.Type<NonNullType<UuidType>>());

            descriptor.Field(f => f.GetTestVariant(default, default))
                .Authorize(AuthorizationPolicyNames.InstructorsOnly)
                .Type<TestVariantDtoGraphType>()
                .Name("testVariant")
                .UseSingleOrDefault()
                .UseFiltering<TestVariantDto>(filterDescriptor =>
                    filterDescriptor.Filter(e => e.Id).AllowEquals());

            descriptor.Field(f => f.GetTestVariants(default, default))
                .Authorize(AuthorizationPolicyNames.InstructorsOnly)
                .Type<NonNullType<ListType<NonNullType<TestVariantDtoGraphType>>>>()
                .Name("testVariants")
                .UseOffsetBasedPaging<TestVariantDtoGraphType, TestVariantDto>();
            // .UseCustomSelection<TestVariantDto>(); // problem with second select for nested collections (mb issue with ef core)
        }
    }
}