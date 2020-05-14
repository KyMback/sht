using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using MediatR;
using SHT.Application.Common;
using SHT.Application.Questions.Contracts;
using SHT.Application.Questions.Create;
using SHT.Application.Questions.Update;
using SHT.Application.Tests.AnswersRatings.Contracts;
using SHT.Application.Tests.AnswersRatings.Rank;
using SHT.Application.Tests.StudentQuestions.Answer;
using SHT.Application.Tests.StudentQuestions.Contracts;
using SHT.Application.Tests.StudentsTestSessions.StateTransition;
using SHT.Application.Tests.TestSessions.Contracts;
using SHT.Application.Tests.TestSessions.Contracts.Edit;
using SHT.Application.Tests.TestSessions.Create;
using SHT.Application.Tests.TestSessions.StateTransition;
using SHT.Application.Tests.TestSessions.Update;
using SHT.Application.Users.Accounts.ConfirmEmail;
using SHT.Application.Users.Accounts.Contracts;
using SHT.Application.Users.Accounts.ResendEmailConfirmation;
using SHT.Application.Users.Accounts.SetCulture;
using SHT.Application.Users.Accounts.SignIn;
using SHT.Application.Users.Accounts.SignOut;
using SHT.Application.Users.Instructors.Contracts;
using SHT.Application.Users.Instructors.SignUp;
using SHT.Application.Users.Students.Contracts;
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

        public Task<Unit> SignUpInstructor(SignUpInstructorDataDto data)
        {
            return _mediator.Send(new SignUpInstructorRequest(data));
        }

        public Task<Unit> SignOut()
        {
            return _mediator.Send(new SignOutRequest());
        }

        public Task<Unit> ConfirmEmail(ConfirmEmailDataDto data)
        {
            return _mediator.Send(new ConfirmEmailRequest(data));
        }

        public Task<Unit> ResendEmailConfirmation(string email)
        {
            return _mediator.Send(new ResendEmailConfirmationRequest(email));
        }

        public Task<Unit> AnswerStudentQuestion(AnswerStudentQuestionDto data)
        {
            return _mediator.Send(new AnswerStudentQuestionRequest(data));
        }

        public Task<Unit> StudentTestSessionStateTransition(
            Guid studentTestSessionId,
            string trigger,
            string serializedData)
        {
            var data = !string.IsNullOrEmpty(serializedData)
                ? JsonSerializer.Deserialize<IDictionary<string, string>>(serializedData)
                : null;
            return _mediator.Send(new StudentTestSessionStateTransitionRequest(studentTestSessionId, trigger, data));
        }

        public Task<CreatedEntityResponse> CreateTestSession(TestSessionModificationData data)
        {
            return _mediator.Send(new CreateTestSessionRequest(data));
        }

        public Task<Unit> UpdateTestSession(TestSessionModificationData data, Guid testSessionId)
        {
            return _mediator.Send(new UpdateTestSessionRequest(data, testSessionId));
        }

        public Task<Unit> TestSessionStateTransition(Guid testSessionId, string trigger)
        {
            return _mediator.Send(new TestSessionStateTransitionRequest(testSessionId, trigger));
        }

        public Task<CreatedEntityResponse> CreateQuestion(QuestionEditDetailsDto data)
        {
            return _mediator.Send(new CreateQuestionRequest(data));
        }

        public Task<Unit> UpdateQuestion(Guid id, QuestionEditDetailsDto data)
        {
            return _mediator.Send(new UpdateQuestionRequest(data, id));
        }

        public Task<Unit> RankQuestionsAnswers(AnswersRatingEditDto data)
        {
            return _mediator.Send(new RankQuestionsAnswersRequest(data));
        }
    }
}