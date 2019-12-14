using System;
using SHT.Domain.Models.Common;

namespace SHT.Domain.Models.Tests
{
    public class Question : BaseEntity, IHasCreatedBy
    {
        public string Text { get; set; }

        public QuestionType Type { get; set; }

        public Guid CreatedById { get; set; }
    }
}