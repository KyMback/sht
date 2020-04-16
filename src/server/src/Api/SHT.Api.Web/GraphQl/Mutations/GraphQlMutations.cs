using HotChocolate.Types;
using SHT.Api.Web.GraphQl.Common;
using SHT.Api.Web.GraphQl.Mutations.Types;
using SHT.Api.Web.Security.Constants;
using SHT.Application.Tests.TestSessions.Contracts;

namespace SHT.Api.Web.GraphQl.Mutations
{
    public class GraphQlMutations : ObjectType<GraphQlMutationHandlers>
    {
        protected override void Configure(IObjectTypeDescriptor<GraphQlMutationHandlers> descriptor)
        {
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
                    argumentDescriptor.Type<NonNullType<TestSessionDtoGraphInputType>>());

            descriptor.Field(e => e.UpdateTestSession(default))
                .Name("updateTestSession")
                .Type<VoidType>()
                .Authorize(AuthorizationPolicyNames.InstructorsOnly)
                .Argument("data", argumentDescriptor =>
                    argumentDescriptor.Type<NonNullType<TestSessionDtoGraphInputType>>());

            descriptor.Field(e => e.TestSessionStateTransition(default, default))
                .Name("testSessionStateTransition")
                .Type<VoidType>()
                .Authorize(AuthorizationPolicyNames.InstructorsOnly)
                .Argument("testSessionId", argumentDescriptor =>
                    argumentDescriptor.Type<NonNullType<UuidType>>())
                .Argument("trigger", argumentDescriptor =>
                    argumentDescriptor.Type<NonNullType<StringType>>());
        }
    }

    #pragma warning disable
    public class TestSessionDtoGraphInputType : InputObjectType<TestSessionDetailsDto>
    {
        protected override void Configure(IInputObjectTypeDescriptor<TestSessionDetailsDto> descriptor)
        {
            // add separate models for update and create
            descriptor.Field(e => e.Id).Type<UuidType>();
            descriptor.Field(e => e.Name).Type<NonNullType<StringType>>();
            descriptor.Field(e => e.StudentsIds).Type<NonNullType<ListType<NonNullType<UuidType>>>>();
            descriptor.Field(e => e.TestVariants)
                .Type<NonNullType<ListType<NonNullType<TestSessionVariantDataDtoInputGraphType>>>>();
        }
    }

    public class TestSessionVariantDataDtoInputGraphType : InputObjectType<TestSessionVariantDataDto>
    {
        protected override void Configure(IInputObjectTypeDescriptor<TestSessionVariantDataDto> descriptor)
        {
            descriptor.Field(e => e.Name).Type<NonNullType<StringType>>();
            descriptor.Field(e => e.TestVariantId).Type<UuidType>();
        }
    }
}