using System.Threading.Tasks;
using HotChocolate;
using SHT.Application.Users.Accounts.GetContext;
using SHT.Domain.Services.Users.Accounts;
using SHT.Infrastructure.Common;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Api.Web.GraphQl.GraphTypes
{
    public class GraphQueries
    {
        public async Task<UserContextDto> GetContext(
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
    }
}