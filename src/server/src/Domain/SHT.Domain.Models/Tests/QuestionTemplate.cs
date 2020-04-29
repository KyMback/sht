using System;
using SHT.Domain.Models.Common;

namespace SHT.Domain.Models.Tests
{
    public class QuestionTemplate : BaseEntity, IHasCreatedBy
    {
        public string Name { get; set; }

        public string Text { get; set; }

        public QuestionType Type { get; set; }

        public Guid CreatedById { get; set; }
    }
}