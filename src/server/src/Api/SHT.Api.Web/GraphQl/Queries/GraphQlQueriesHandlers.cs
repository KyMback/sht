using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SHT.Application.Common;
using SHT.Application.Questions.Contracts;
using SHT.Application.Questions.GetAll;
using SHT.Application.Tests.StudentQuestions.Contracts;
using SHT.Application.Tests.StudentQuestions.GetAll;
using SHT.Application.Tests.StudentsTestSessions.Contracts;
using SHT.Application.Tests.StudentsTestSessions.GetAll;
using SHT.Application.Tests.StudentsTestSessions.GetTriggers;
using SHT.Application.Tests.StudentsTestSessions.GetVariants;
using SHT.Application.Tests.TestSessions.Contracts;
using SHT.Application.Tests.TestSessions.GetAll;
using SHT.Application.Tests.TestSessions.GetTriggers;
using SHT.Application.TestVariants.Contracts;
using SHT.Application.TestVariants.GetAll;
using SHT.Application.TestVariants.GetLookups;
using SHT.Application.Users.Accounts.Contracts;
using SHT.Application.Users.Accounts.GetPasswordRules;
using SHT.Application.Users.Accounts.GetUserContext;
using SHT.Application.Users.Instructors.Contracts;
using SHT.Application.Users.Instructors.GetProfile;
using SHT.Application.Users.Students.Contracts;
using SHT.Application.Users.Students.GetGroups;
using SHT.Application.Users.Students.GetProfile;

namespace SHT.Api.Web.GraphQl.Queries
{
    public class GraphQlQueriesHandlers
    {
        private readonly IMediator _mediator;

        public GraphQlQueriesHandlers(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task<UserContextDto> GetUserContext()
        {
            return _mediator.Send(new GetUserContextRequest());
        }

        public Task<PasswordRulesDto> GetPasswordRules()
        {
            return _mediator.Send(new GetPasswordRulesRequest());
        }

        public Task<IQueryable<InstructorProfileDto>> GetInstructorProfile()
        {
            return _mediator.Send(new GetInstructorProfileRequest());
        }

        public Task<IQueryable<StudentProfileDto>> GetStudentProfile()
        {
            return _mediator.Send(new GetStudentProfileRequest());
        }

        public Task<IQueryable<TestSessionDetailsDto>> GetTestSessionListItems()
        {
            return _mediator.Send(new GetAllTestSessionsRequest());
        }

        public Task<IQueryable<TestSessionDetailsDto>> GetTestSessionDetails()
        {
            return _mediator.Send(new GetAllTestSessionsRequest());
        }

        public Task<IReadOnlyCollection<string>> GetTestSessionTriggers(Guid testSessionId)
        {
            return _mediator.Send(new GetTestSessionTriggersRequest(testSessionId));
        }

        public Task<IQueryable<Lookup>> GetVariantsLookups()
        {
            return _mediator.Send(new GetTestVariantsLookupsRequest());
        }

        public Task<IReadOnlyCollection<StudentGroupedGroupDto>> GetStudentsGroups()
        {
            return _mediator.Send(new GetStudentsGroupsRequest());
        }

        public Task<IQueryable<StudentTestSessionDto>> GetStudentsTestSessions()
        {
            return _mediator.Send(new GetAllStudentTestSessionsRequest());
        }

        // Just because can't use the same method for different fields
        public Task<IQueryable<StudentTestSessionDto>> GetStudentsTestSessions2()
        {
            return _mediator.Send(new GetAllStudentTestSessionsRequest());
        }

        public Task<IReadOnlyCollection<string>> GetStudentTestSessionTriggers(Guid testSessionId)
        {
            return _mediator.Send(new GetStudentTestSessionTriggersRequest(testSessionId));
        }

        public Task<IQueryable<StudentTestQuestionDto>> GetStudentTestQuestions()
        {
            return _mediator.Send(new GetAllStudentTestQuestionsRequest());
        }

        // Just because can't use the same method for different fields
        public Task<IQueryable<StudentTestQuestionDto>> GetStudentTestQuestion()
        {
            return _mediator.Send(new GetAllStudentTestQuestionsRequest());
        }

        public Task<IReadOnlyCollection<string>> GetStudentTestSessionVariants(Guid studentTestSessionId)
        {
            return _mediator.Send(new GetStudentTestSessionVariantsRequest(studentTestSessionId));
        }

        public Task<IQueryable<TestVariantDto>> GetTestVariants()
        {
            return _mediator.Send(new GetAllTestVariantsRequest());
        }

        // Just because can't use the same method for different fields
        public Task<IQueryable<TestVariantDto>> GetTestVariant()
        {
            return _mediator.Send(new GetAllTestVariantsRequest());
        }

        public Task<IQueryable<QuestionDto>> GetQuestions()
        {
            return _mediator.Send(new GetAllQuestionsRequest());
        }
    }
}