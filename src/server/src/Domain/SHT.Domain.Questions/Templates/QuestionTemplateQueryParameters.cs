using System;
using SHT.Domain.Common.Core;
using SHT.Domain.Models.Questions;

namespace SHT.Domain.Questions.Templates
{
    public class QuestionTemplateQueryParameters : BaseQueryParameters<QuestionTemplate>
    {
        public Guid? Id { get; set; }

        public Guid? CreatedById { get; set; }

        protected override void AddFilters()
        {
            FilterIfHasValue(Id, question => question.Id == Id.Value);
            FilterIfHasValue(CreatedById, question => question.CreatedById == CreatedById.Value);
        }
    }
}