using System;
using SHT.Application.Common;
using SHT.Domain.Models.Users;

namespace SHT.Application.Users.Accounts.GetContext
{
    [ApiDataContract]
    public class UserContextDto
    {
        public Guid? Id { get; set; }

        public UserType? UserType { get; set; }

        public bool IsAuthenticated { get; set; }
    }
}