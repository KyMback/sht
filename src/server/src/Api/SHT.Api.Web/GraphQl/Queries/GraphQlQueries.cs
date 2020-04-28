using HotChocolate.Types;
using SHT.Api.Web.GraphQl.Extensions;
using SHT.Api.Web.GraphQl.Queries.Types;
using SHT.Api.Web.GraphQl.Queries.Types.StudentTestSessions;
using SHT.Api.Web.Security.Constants;
using SHT.Application.Tests.StudentQuestions.Contracts;
using SHT.Application.Tests.StudentsTestSessions.Contracts;
using SHT.Application.Tests.TestSessions.Contracts;
using SHT.Application.TestVariants.Contracts;

namespace SHT.Api.Web.GraphQl.Queries
{
    public class GraphQlQueries : ObjectType<GraphQlQueriesHandlers>
    {
        protected override void Configure(IObjectTypeDescriptor<GraphQlQueriesHandlers> descriptor)
        {
            descriptor
                .Field(f => f.GetUserContext())
                .Type<NonNullType<UserContextGraphType>>()
                .Name("userContext");

            descriptor
                .Field(f => f.GetPasswordRules())
                .Type<NonNullType<PasswordRulesDtoGraphType>>()
                .Name("passwordRules");

            descriptor
                .Field(f => f.GetInstructorProfile())
                .Authorize(AuthorizationPolicyNames.InstructorsOnly)
                .Type<NonNullType<InstructorProfileDtoGraphType>>()
                .Name("instructorProfile")
                .UseSingleOrDefault()
                .UseSelection();

            descriptor
                .Field(f => f.GetStudentProfile())
                .Authorize(AuthorizationPolicyNames.StudentsOnly)
                .Type<NonNullType<StudentProfileDtoGraphType>>()
                .Name("studentProfile")
                .UseSingleOrDefault()
                .UseSelection();

            descriptor
                .Field(f => f.GetTestSessionListItems())
                .Authorize(AuthorizationPolicyNames.InstructorsOnly)
                .Type<NonNullType<ListType<NonNullType<TestSessionDetailsDtoGraphType>>>>()
                .Name("testSessionListItems")
                .UseOffsetBasedPaging<TestSessionDetailsDtoGraphType, TestSessionDetailsDto>()
                .UseCustomSelection<TestSessionDetailsDto>()
                .UseSorting<TestSessionDetailsDto>(typeDescriptor =>
                {
                    typeDescriptor.BindFieldsExplicitly();
                    typeDescriptor.Sortable(e => e.CreatedAt);
                });

            descriptor
                .Field(f => f.GetTestSessionDetails())
                .Authorize(AuthorizationPolicyNames.InstructorsOnly)
                .Type<TestSessionDetailsDtoGraphType>()
                .Name("testSessionDetails")
                .UseSingleOrDefault()
                .UseSelection()
                .UseFiltering<TestSessionDetailsDto>(filterDescriptor =>
                    filterDescriptor.Filter(p => p.Id).AllowEquals());

            descriptor
                .Field(f => f.GetTestSessionTriggers(default))
                .Authorize(AuthorizationPolicyNames.InstructorsOnly)
                .Type<NonNullType<ListType<NonNullType<StringType>>>>()
                .Name("testSessionTriggers")
                .Argument("testSessionId", argumentDescriptor => argumentDescriptor.Type<NonNullType<UuidType>>());

            descriptor
                .Field(f => f.GetVariantsLookups())
                .Authorize(AuthorizationPolicyNames.InstructorsOnly)
                .Type<NonNullType<ListType<NonNullType<LookupGraphType>>>>()
                .Name("testVariantLookups")
                .UseSelection();

            descriptor
                .Field(f => f.GetStudentsGroups())
                .Authorize()
                .Type<NonNullType<ListType<NonNullType<StudentGroupedGroupDtoGraphType>>>>()
                .Name("studentsGroups");

            descriptor
                .Field(f => f.GetStudentsTestSessions())
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
                .Field(f => f.GetStudentsTestSessions2())
                .Authorize(AuthorizationPolicyNames.StudentsOnly)
                .Type<StudentTestSessionDtoGraphType>()
                .Name("studentTestSession")
                .UseSingleOrDefault()
                .UseSelection()
                .UseFiltering<StudentTestSessionDto>(filterDescriptor =>
                    filterDescriptor.Filter(e => e.Id).AllowEquals());

            descriptor
                .Field(f => f.GetStudentTestSessionTriggers(default))
                .Authorize(AuthorizationPolicyNames.StudentsOnly)
                .Type<NonNullType<ListType<NonNullType<StringType>>>>()
                .Name("studentTestSessionTriggers")
                .Argument("testSessionId", argumentDescriptor => argumentDescriptor.Type<NonNullType<UuidType>>());

            descriptor
                .Field(f => f.GetStudentTestQuestions())
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
                .Field(f => f.GetStudentTestQuestion())
                .Authorize(AuthorizationPolicyNames.StudentsOnly)
                .Type<StudentTestQuestionDtoGraphType>()
                .Name("studentTestQuestion")
                .UseSingleOrDefault()
                .UseSelection()
                .UseFiltering<StudentTestQuestionDtoFilterInputType>();

            descriptor
                .Field(f => f.GetStudentTestSessionVariants(default))
                .Authorize(AuthorizationPolicyNames.StudentsOnly)
                .Type<NonNullType<ListType<NonNullType<StringType>>>>()
                .Name("studentTestSessionVariants")
                .Argument("studentTestSessionId", argumentDescriptor => argumentDescriptor.Type<NonNullType<UuidType>>());

            descriptor.Field(f => f.GetTestVariant())
                .Authorize(AuthorizationPolicyNames.InstructorsOnly)
                .Type<TestVariantDtoGraphType>()
                .Name("testVariant")
                .UseSingleOrDefault()
                .UseFiltering<TestVariantDto>(filterDescriptor =>
                    filterDescriptor.Filter(e => e.Id).AllowEquals());

            descriptor.Field(f => f.GetTestVariants())
                .Authorize(AuthorizationPolicyNames.InstructorsOnly)
                .Type<NonNullType<ListType<NonNullType<TestVariantDtoGraphType>>>>()
                .Name("testVariants")
                .UseOffsetBasedPaging<TestVariantDtoGraphType, TestVariantDto>()
                .UseCustomSelection<TestVariantDto>();
        }
    }
}