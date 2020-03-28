using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using SHT.Application.Common;
using SHT.Domain.Models.Tests;

namespace SHT.Application.TestVariants.Contracts
{
    [ApiDataContract]
    public class TestVariantQuestionDto
    {
        public static readonly Expression<Func<TestVariantQuestion, TestVariantQuestionDto>> Selector =
            e => new TestVariantQuestionDto
            {
                Id = e.Id,
                Number = e.Number,
                Type = e.Type,
                // TODO: change this stub
                ShortQuestionLabel = e.Text.Substring(0, 50),
            };

        public Guid Id { get; set; }

        public QuestionType Type { get; set; }

        public string Number { get; set; }

        public string ShortQuestionLabel { get; set; }
    }
}