using System;
using SHT.Domain.Common.Core;
using SHT.Domain.Models.Tests;

namespace SHT.Domain.Questions.Templates
{
    public class QuestionTemplateQueryParameters : BaseQueryParameters<QuestionTemplate>
    {
        public Guid? Id { get; set; }

        protected override void AddFilters()
        {
            FilterIfHasValue(Id, question => question.Id == Id.Value);
        }
    }
}