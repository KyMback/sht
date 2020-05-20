using System;
using SHT.Domain.Models.Common;

namespace SHT.Domain.Models.Users
{
    public class Account : BaseEntity, IHasCreatedAt, IHasOrganization
    {
        public string Email { get; set; }

        public string Password { get; set; }

        /// <remarks>
        /// Represents current version of user credentials
        /// </remarks>
        public string SecurityStamp { get; set; }

        public UserType UserType { get; set; }

        public bool IsEmailConfirmed { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? ActivatedAt { get; set; }

        public Guid OrganizationId { get; set; }

        public virtual Organization Organization { get; set; }
    }
}