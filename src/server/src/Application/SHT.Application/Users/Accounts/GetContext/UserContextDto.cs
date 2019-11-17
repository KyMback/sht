using System;
using SHT.Domain.Models.Users;

namespace SHT.Application.Users.Accounts.GetContext
{
    public class UserContextDto
    {
        public Guid? Id { get; set; }

        public UserType? UserType { get; set; }

        public bool IsAuthenticated { get; set; }
    }
}