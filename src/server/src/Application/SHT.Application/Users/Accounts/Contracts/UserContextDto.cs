using System;
using System.Linq.Expressions;
using SHT.Application.Common;
using SHT.Domain.Models.Users;

namespace SHT.Application.Users.Accounts.GetContext
{
    [ApiDataContract]
    public class UserContextDto
    {
        public static readonly Expression<Func<Account, UserContextDto>> Selector = account => new UserContextDto
        {
            Id = account.Id,
            UserType = account.UserType,
        };

        public Guid? Id { get; set; }

        public UserType? UserType { get; set; }

        public bool IsAuthenticated { get; set; }
    }
}