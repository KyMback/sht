using System;
using SHT.Domain.Models.Tests;
using SHT.Domain.Services.Common;

namespace SHT.Domain.Services.Tests.Questions
{
    public class QuestionQueryParameters : BaseQueryParameters<Question>
    {
        public Guid? Id { get; set; }

        protected override void AddFilters()
        {
            FilterIfHasValue(Id, question => question.Id == Id.Value);
        }
    }
}