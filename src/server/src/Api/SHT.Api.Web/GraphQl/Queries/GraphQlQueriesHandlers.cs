using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using SHT.Application.Common;
using SHT.Application.StateMachineConfigs.Core;
using SHT.Application.Tests.StudentQuestions.Contracts;
using SHT.Application.Tests.StudentsTestSessions.Contracts;
using SHT.Application.Tests.TestSessions.Contracts;
using SHT.Application.TestVariants.Contracts;
using SHT.Application.Users.Accounts.GetContext;
using SHT.Application.Users.Students.Contracts;
using SHT.Domain.Models.Tests;
using SHT.Domain.Models.Tests.Students;
using SHT.Domain.Services.Tests;
using SHT.Domain.Services.Tests.Student;
using SHT.Domain.Services.Tests.Student.Questions;
using SHT.Domain.Services.Tests.Variants;
using SHT.Domain.Services.Users;
using SHT.Domain.Services.Users.Accounts;
using SHT.Infrastructure.Common;
using SHT.Infrastructure.DataAccess.Abstractions;
using IQueryProvider = SHT.Infrastructure.DataAccess.Abstractions.IQueryProvider;

namespace SHT.Api.Web.GraphQl.Queries
{
    public class GraphQlQueriesHandlers
    {
        public async Task<UserContextDto> GetUserContext(
            [Service] IUnitOfWork unitOfWork,
            [Service] IExecutionContextAccessor executionContextAccessor)
        {
            var queryParameters = new AccountQueryParameters(executionContextAccessor.GetCurrentUserId());
            var data = await unitOfWork.GetSingleOrDefault(queryParameters, UserContextDto.Selector);

            if (data != null)
            {
                data.IsAuthenticated = true;
            }

            return data ?? new UserContextDto();
        }

        public IQueryable<TestSessionListItemDto> GetTestSessionListItems(
            [Service] IExecutionContextAccessor executionContextAccessor,
            [Service] IQueryProvider queryProvider)
        {
            var queryParameters = new TestSessionQueryParameters
            {
                InstructorId = executionContextAccessor.GetCurrentUserId(),
            };

            return queryParameters.ToQuery(queryProvider).Select(TestSessionListItemDto.Selector);
        }

        public IQueryable<TestSessionDetailsDto> GetTestSessionDetails(
            [Service] IExecutionContextAccessor executionContextAccessor,
            [Service] IQueryProvider queryProvider)
        {
            var queryParameters = new TestSessionQueryParameters
            {
                InstructorId = executionContextAccessor.GetCurrentUserId(),
            };

            return queryParameters.ToQuery(queryProvider).Select(TestSessionDetailsDto.Selector);
        }

        public async Task<IReadOnlyCollection<string>> GetTestSessionTriggers(
            Guid testSessionId,
            [Service] IStateManager<TestSession> stateManager,
            [Service] IUnitOfWork unitOfWork)
        {
            var queryParameters = new TestSessionQueryParameters(testSessionId);
            var testSession = await unitOfWork.GetSingle(queryParameters);
            return await stateManager.GetAvailableTriggers(testSession);
        }

        public IQueryable<Lookup> GetVariantsLookups(
            [Service] IExecutionContextAccessor executionContextAccessor,
            [Service] IQueryProvider queryProvider)
        {
            var queryParameters = new TestVariantQueryParameters
            {
                CreatedById = executionContextAccessor.GetCurrentUserId(),
            };

            return queryParameters.ToQuery(queryProvider).Select(LookupSelectors.VariantSelector);
        }

        public async Task<IReadOnlyCollection<StudentGroupedGroupDto>> GetStudentsGroups(
            [Service] IUnitOfWork unitOfWork)
        {
            var queryParameters = new StudentQueryParameters
            {
                IsUniq = true,
            };

            var result = await unitOfWork.GetAll(queryParameters, student => new
            {
                student.Id,
                student.Group,
            });

            return result
                .GroupBy(e => e.Group, arg => arg.Id)
                .Select(group =>
                    new StudentGroupedGroupDto
                    {
                        GroupName = group.Key,
                        StudentsIds = group.ToArray(),
                    }).ToArray();
        }

        public IQueryable<StudentTestSessionDto> GetStudentsTestSessions(
            [Service] IExecutionContextAccessor executionContextAccessor,
            [Service] IQueryProvider queryProvider)
        {
            var queryParameters = new StudentTestSessionQueryParameters
            {
                StudentId = executionContextAccessor.GetCurrentUserId(),
                ExceptTestSessionState = TestSessionStates.Pending,
            };

            return queryParameters.ToQuery(queryProvider).Select(StudentTestSessionDto.Selector);
        }

        // Just because can't use the same method for different fields
        public IQueryable<StudentTestSessionDto> GetStudentsTestSessions2(
            [Service] IExecutionContextAccessor executionContextAccessor,
            [Service] IQueryProvider queryProvider)
        {
            return GetStudentsTestSessions(executionContextAccessor, queryProvider);
        }

        public async Task<IReadOnlyCollection<string>> GetStudentTestSessionTriggers(
            Guid testSessionId,
            [Service] IExecutionContextAccessor executionContextAccessor,
            [Service] IStateManager<StudentTestSession> stateManager,
            [Service] IUnitOfWork unitOfWork)
        {
            var queryParameters = new StudentTestSessionQueryParameters(testSessionId)
            {
                StudentId = executionContextAccessor.GetCurrentUserId(),
            };
            var testSession = await unitOfWork.GetSingle(queryParameters);
            return await stateManager.GetAvailableTriggers(testSession);
        }

        public IQueryable<StudentTestQuestionDto> GetStudentTestQuestions(
            [Service] IExecutionContextAccessor executionContextAccessor,
            [Service] IQueryProvider queryProvider)
        {
            var queryParameters = new StudentQuestionQueryParameters
            {
                StudentId = executionContextAccessor.GetCurrentUserId(),
            };

            return queryParameters.ToQuery(queryProvider).Select(StudentTestQuestionDto.Selector);
        }

        // Just because can't use the same method for different fields
        public IQueryable<StudentTestQuestionDto> GetStudentTestQuestion(
            [Service] IExecutionContextAccessor executionContextAccessor,
            [Service] IQueryProvider queryProvider)
        {
            return GetStudentTestQuestions(executionContextAccessor, queryProvider);
        }

        public async Task<IReadOnlyCollection<string>> GetStudentTestSessionVariants(
            Guid studentTestSessionId,
            [Service] IExecutionContextAccessor executionContextAccessor,
            [Service] IUnitOfWork unitOfWork)
        {
            var queryParameters = new StudentTestSessionQueryParameters
            {
                Id = studentTestSessionId,
                StudentId = executionContextAccessor.GetCurrentUserId(),
            };

            var result = await unitOfWork.GetSingle(
                queryParameters,
                session => session.TestSession.TestSessionTestVariants.Select(e => e.Name).ToArray());

            return result;
        }

        public IQueryable<TestVariantDto> GetTestVariants(
            [Service] IExecutionContextAccessor executionContextAccessor,
            [Service] IQueryProvider queryProvider)
        {
            var queryParameters = new TestVariantQueryParameters
            {
                CreatedById = executionContextAccessor.GetCurrentUserId(),
            };

            return queryParameters.ToQuery(queryProvider).Select(TestVariantDto.Selector);
        }

        // Just because can't use the same method for different fields
        public IQueryable<TestVariantDto> GetTestVariant(
            [Service] IExecutionContextAccessor executionContextAccessor,
            [Service] IQueryProvider queryProvider)
        {
            return GetTestVariants(executionContextAccessor, queryProvider);
        }
    }
}