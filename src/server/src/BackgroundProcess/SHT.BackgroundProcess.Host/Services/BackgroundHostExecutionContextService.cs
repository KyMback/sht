using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using SHT.BackgroundProcess.Host.Options;
using SHT.Domain.Users.Accounts;
using SHT.Infrastructure.Common.ExecutionContext;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.BackgroundProcess.Host.Services
{
    internal class BackgroundHostExecutionContextService : IExecutionContextService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOptions<ExecutionContextOptions> _executionContextOptions;
        private Lazy<UserContextData> _lazyUserContextData;

        public BackgroundHostExecutionContextService(
            IUnitOfWork unitOfWork,
            IOptions<ExecutionContextOptions> executionContextOptions)
        {
            _unitOfWork = unitOfWork;
            _executionContextOptions = executionContextOptions;
            _lazyUserContextData = new Lazy<UserContextData>(GetSystemUserData);
        }

        public Guid GetCurrentUserId() => _lazyUserContextData.Value.UserId;

        public void SetExecutionContext(IExecutionContext context)
        {
            _lazyUserContextData = new Lazy<UserContextData>(() => GetUserData(context));
        }

        private UserContextData GetSystemUserData()
        {
            var queryParameters =
                new AccountQueryParameters(email: _executionContextOptions.Value.DefaultSystemUserEmail);

            return GetUserData(queryParameters).GetAwaiter().GetResult();
        }

        private UserContextData GetUserData(IExecutionContext executionContext)
        {
            var queryParameters = new AccountQueryParameters(id: executionContext.UserId);

            return GetUserData(queryParameters).GetAwaiter().GetResult();
        }

        private Task<UserContextData> GetUserData(AccountQueryParameters queryParameters)
        {
            return _unitOfWork.GetSingle(queryParameters, user => new UserContextData
            {
                Email = user.Email,
                UserId = user.Id,
            });
        }

        private class UserContextData
        {
            public Guid UserId { get; set; }

            public string Email { get; set; }
        }
    }
}
