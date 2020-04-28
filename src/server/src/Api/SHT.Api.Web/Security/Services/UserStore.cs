using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SHT.Domain.Models.Users;
using SHT.Domain.Services.Users.Accounts;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Api.Web.Security.Services
{
    internal class UserStore : IUserPasswordStore<Account>, IUserEmailStore<Account>, IUserSecurityStampStore<Account>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserStore(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IdentityResult> CreateAsync(Account account, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await _unitOfWork.Add(account);
            return IdentityResult.Success;
        }

        public Task<IdentityResult> DeleteAsync(Account account, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Account> FindByIdAsync(string accountId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return _unitOfWork.GetSingleOrDefault(new AccountQueryParameters(Guid.Parse(accountId)));
        }

        public Task<Account> FindByNameAsync(string normalizedEmail, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return _unitOfWork.GetSingleOrDefault(new AccountQueryParameters(normalizedEmail: normalizedEmail));
        }

        public Task<string> GetNormalizedUserNameAsync(Account account, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return Task.FromResult(account.Email.ToUpperInvariant());
        }

        public Task<string> GetUserIdAsync(Account account, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return Task.FromResult(account.Id.ToString());
        }

        public Task<string> GetUserNameAsync(Account account, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return Task.FromResult(account.Email);
        }

        public Task SetNormalizedUserNameAsync(
            Account account,
            string normalizedName,
            CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task SetUserNameAsync(Account account, string accountName, CancellationToken cancellationToken)
        {
            account.Email = accountName;
            return Task.CompletedTask;
        }

        public async Task<IdentityResult> UpdateAsync(Account account, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await _unitOfWork.Update(account);
            return IdentityResult.Success;
        }

        public Task<string> GetPasswordHashAsync(Account account, CancellationToken cancellationToken)
        {
            return Task.FromResult(account.Password);
        }

        public Task<bool> HasPasswordAsync(Account account, CancellationToken cancellationToken)
        {
            return Task.FromResult(!string.IsNullOrWhiteSpace(account.Password));
        }

        public Task SetPasswordHashAsync(Account account, string passwordHash, CancellationToken cancellationToken)
        {
            account.Password = passwordHash;
            return Task.CompletedTask;
        }

        public Task<Account> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return _unitOfWork.GetSingleOrDefault(new AccountQueryParameters(normalizedEmail: normalizedEmail));
        }

        public Task<string> GetEmailAsync(Account user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return Task.FromResult(user.Email);
        }

        public Task<bool> GetEmailConfirmedAsync(Account user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return Task.FromResult(user.IsEmailConfirmed);
        }

        public Task<string> GetNormalizedEmailAsync(Account user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return Task.FromResult(user.Email.ToUpperInvariant());
        }

        public Task SetEmailAsync(Account user, string email, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            user.Email = email;
            return Task.CompletedTask;
        }

        public Task SetEmailConfirmedAsync(Account user, bool confirmed, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            user.IsEmailConfirmed = confirmed;
            return _unitOfWork.Update(user);
        }

        public Task SetNormalizedEmailAsync(Account user, string normalizedEmail, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return Task.CompletedTask;
        }

        public Task<string> GetSecurityStampAsync(Account user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return Task.FromResult(user.SecurityStamp);
        }

        public Task SetSecurityStampAsync(Account user, string stamp, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            user.SecurityStamp = stamp;
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        ///     Implementation for disposable.
        /// </summary>
        /// <param name="disposing">A value indicating whether object was disposed.</param>
        protected virtual void Dispose(bool disposing)
        {
        }
    }
}