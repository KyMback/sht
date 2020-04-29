using System;
using SHT.Domain.Common.Core;
using SHT.Domain.Models.Users;

namespace SHT.Domain.Services.Users
{
    public class StudentQueryParameters : BaseQueryParameters<Student>
    {
        public StudentQueryParameters(Guid? id = default)
        {
            Id = id;
        }

        public Guid? Id { get; set; }

        protected override void AddFilters()
        {
            FilterIfHasValue(Id, student => student.Id == Id.Value);
        }
    }
}