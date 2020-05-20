using System;

namespace SHT.Domain.Models.Common
{
    public interface IHasOrganization
    {
        public Guid OrganizationId { get; set; }

        public Organization Organization { get; set; }
    }
}