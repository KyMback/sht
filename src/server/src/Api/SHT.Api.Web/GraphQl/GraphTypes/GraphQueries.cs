using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using SHT.Application.Tests.TestSessions.Contracts;
using SHT.Application.Users.Accounts.GetContext;
using SHT.Domain.Services.Tests;
using SHT.Domain.Services.Users.Accounts;
using SHT.Infrastructure.Common;
using SHT.Infrastructure.DataAccess.Abstractions;
using IQueryProvider = SHT.Infrastructure.DataAccess.Abstractions.IQueryProvider;

namespace SHT.Api.Web.GraphQl.GraphTypes
{
    public class GraphQueries
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
    }
}