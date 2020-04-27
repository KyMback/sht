using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using SHT.Application.Common;
using SHT.Application.Tests.StudentQuestions.Answer;
using SHT.Application.Tests.StudentsTestSessions.StateTransition;
using SHT.Application.Tests.TestSessions.Contracts;
using SHT.Application.Tests.TestSessions.Create;
using SHT.Application.Tests.TestSessions.StateTransition;
using SHT.Application.Tests.TestSessions.Update;
using SHT.Application.Users.Accounts.ConfirmEmail;
using SHT.Application.Users.Accounts.SetCulture;
using SHT.Application.Users.Accounts.SignIn;
using SHT.Application.Users.Accounts.SignOut;
using SHT.Application.Users.Students.SignUp;

namespace SHT.Api.Web.GraphQl.Mutations
{
    public class GraphQlMutationHandlers
    {
        private readonly IMediator _mediator;

        public GraphQlMutationHandlers(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task<Unit> SetCulture(string culture)
        {
            return _mediator.Send(new SetCultureRequest(culture));
        }

        public Task<SignInResponse> SingIn(SignInDataDto data)
        {
            return _mediator.Send(new SignInRequest(data));
        }

        public Task<Unit> SignUpStudent(SignUpStudentDataDto data)
        {
            return _mediator.Send(new SignUpStudentRequest(data));
        }

        public Task<Unit> SignOut()
        {
            return _mediator.Send(new SignOutRequest());
        }

        public Task<Unit> ConfirmEmail(ConfirmEmailDataDto data)
        {
            return _mediator.Send(new ConfirmEmailRequest(data));
        }

        public Task<Unit> AnswerStudentQuestion(AnswerStudentQuestionDto data)
        {
            return _mediator.Send(new AnswerStudentQuestionRequest(data));
        }

        public Task<Unit> StudentTestSessionStateTransition(
            Guid studentTestSessionId,
            string trigger,
            IDictionary<string, string> serializedData)
        {
            return _mediator.Send(
                new StudentTestSessionStateTransitionRequest(studentTestSessionId, trigger, serializedData));
        }

        public Task<CreatedEntityResponse> CreateTestSession(TestSessionModificationDataDto data)
        {
            return _mediator.Send(new CreateTestSessionRequest(data));
        }

        public Task<Unit> UpdateTestSession(TestSessionModificationDataDto data, Guid testSessionId)
        {
            return _mediator.Send(new UpdateTestSessionRequest(data, testSessionId));
        }

        public Task<Unit> TestSessionStateTransition(Guid testSessionId, string trigger)
        {
            return _mediator.Send(new TestSessionStateTransitionRequest(testSessionId, trigger));
        }
    }
}