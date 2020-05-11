using HotChocolate.Types;
using SHT.Api.Web.GraphQl.Common;
using SHT.Api.Web.GraphQl.Mutations.Types;
using SHT.Api.Web.GraphQl.Mutations.Types.TestSession;
using SHT.Api.Web.Security.Constants;

namespace SHT.Api.Web.GraphQl.Mutations
{
    public class GraphQlMutations : ObjectType<GraphQlMutationHandlers>
    {
        protected override void Configure(IObjectTypeDescriptor<GraphQlMutationHandlers> descriptor)
        {
            ConfigureAccount(descriptor);
            ConfigureTestSessions(descriptor);
            ConfigureQuestions(descriptor);
        }

        private void ConfigureAccount(IObjectTypeDescriptor<GraphQlMutationHandlers> descriptor)
        {
            descriptor.Field(e => e.SetCulture(default))
                .Type<VoidType>()
                .Argument("culture", argumentDescriptor =>
                    argumentDescriptor.Type<NonNullType<StringType>>());

            descriptor.Field(e => e.SingIn(default))
                .Type<NonNullType<SignInResponseGraphType>>()
                .Name("signIn")
                .Argument("data", argumentDescriptor =>
                    argumentDescriptor.Type<NonNullType<SignInDataDtoInputGraphType>>());

            descriptor.Field(e => e.SignUpStudent(default))
                .Name("signUpStudent")
                .Type<VoidType>()
                .Argument("data", argumentDescriptor =>
                    argumentDescriptor.Type<NonNullType<SignUpStudentDataDtoInputGraphType>>());

            descriptor.Field(e => e.SignOut())
                .Name("signOut")
                .Type<VoidType>();

            descriptor.Field(e => e.ConfirmEmail(default))
                .Name("confirmEmail")
                .Type<VoidType>()
                .Argument("data", argumentDescriptor =>
                    argumentDescriptor.Type<NonNullType<ConfirmEmailDataDtoInputGraphType>>());

            descriptor.Field(e => e.ResendEmailConfirmation(default))
                .Name("resendEmailConfirmation")
                .Type<VoidType>()
                .Argument("email", argumentDescriptor =>
                    argumentDescriptor.Type<NonNullType<StringType>>());
        }

        private void ConfigureTestSessions(IObjectTypeDescriptor<GraphQlMutationHandlers> descriptor)
        {
            descriptor.Field(e => e.AnswerStudentQuestion(default))
                .Name("answerStudentQuestion")
                .Type<VoidType>()
                .Authorize(AuthorizationPolicyNames.StudentsOnly)
                .Argument("data", argumentDescriptor =>
                    argumentDescriptor.Type<NonNullType<AnswerStudentQuestionDtoInputGraphType>>());

            descriptor.Field(e =>
                    e.StudentTestSessionStateTransition(default, default, default))
                .Name("studentTestSessionStateTransition")
                .Type<VoidType>()
                .Authorize(AuthorizationPolicyNames.StudentsOnly)
                .Argument("studentTestSessionId", argumentDescriptor =>
                    argumentDescriptor.Type<NonNullType<UuidType>>())
                .Argument("trigger", argumentDescriptor =>
                    argumentDescriptor.Type<NonNullType<StringType>>())
                .Argument("serializedData", argumentDescriptor =>
                    argumentDescriptor.Type<AnyType>());

            descriptor.Field(e => e.CreateTestSession(default))
                .Name("createTestSession")
                .Type<NonNullType<CreatedEntityResponseGraphType>>()
                .Authorize(AuthorizationPolicyNames.InstructorsOnly)
                .Argument("data", argumentDescriptor =>
                    argumentDescriptor.Type<NonNullType<TestSessionInputGraphType>>());

            descriptor.Field(e => e.UpdateTestSession(default, default))
                .Name("updateTestSession")
                .Type<VoidType>()
                .Authorize(AuthorizationPolicyNames.InstructorsOnly)
                .Argument("testSessionId", argumentDescriptor =>
                    argumentDescriptor.Type<NonNullType<IdType>>())
                .Argument("data", argumentDescriptor =>
                    argumentDescriptor.Type<NonNullType<TestSessionInputGraphType>>());

            descriptor.Field(e => e.TestSessionStateTransition(default, default))
                .Name("testSessionStateTransition")
                .Type<VoidType>()
                .Authorize(AuthorizationPolicyNames.InstructorsOnly)
                .Argument("testSessionId", argumentDescriptor =>
                    argumentDescriptor.Type<NonNullType<UuidType>>())
                .Argument("trigger", argumentDescriptor =>
                    argumentDescriptor.Type<NonNullType<StringType>>());
        }

        private void ConfigureQuestions(IObjectTypeDescriptor<GraphQlMutationHandlers> descriptor)
        {
            descriptor.Field(e => e.CreateQuestion(default))
                .Name("createQuestion")
                .Type<NonNullType<CreatedEntityResponseGraphType>>()
                .Authorize(AuthorizationPolicyNames.InstructorsOnly)
                .Argument("data", argumentDescriptor =>
                    argumentDescriptor.Type<NonNullType<QuestionEditDetailsDtoInputGraphType>>());

            descriptor.Field(e => e.UpdateQuestion(default, default))
                .Name("updateQuestion")
                .Type<VoidType>()
                .Authorize(AuthorizationPolicyNames.InstructorsOnly)
                .Argument("id", argumentDescriptor =>
                    argumentDescriptor.Type<NonNullType<UuidType>>())
                .Argument("data", argumentDescriptor =>
                    argumentDescriptor.Type<NonNullType<QuestionEditDetailsDtoInputGraphType>>());
        }
    }
}