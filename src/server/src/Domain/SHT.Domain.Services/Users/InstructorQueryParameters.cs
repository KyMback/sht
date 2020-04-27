using System;
using SHT.Domain.Models.Users;
using SHT.Domain.Services.Common;

namespace SHT.Domain.Services.Users
{
    public class InstructorQueryParameters : BaseQueryParameters<Instructor>
    {
        public InstructorQueryParameters(Guid? id = default)
        {
            Id = id;
        }

        public Guid? Id { get; set; }

        protected override void AddFilters()
        {
            FilterIfHasValue(Id, instructor => instructor.Id == Id.Value);
        }
    }
}