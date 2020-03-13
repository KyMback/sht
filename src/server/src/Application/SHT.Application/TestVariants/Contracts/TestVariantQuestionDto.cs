using System;
using System.ComponentModel.DataAnnotations;
using SHT.Application.Common;
using SHT.Domain.Models.Tests;

namespace SHT.Application.TestVariants.Contracts
{
    [ApiDataContract]
    public class TestVariantQuestionDto
    {
        public Guid Id { get; set; }

        public QuestionType Type { get; set; }

        [Required]
        public string Number { get; set; }

        [Required]
        public string ShortQuestionLabel { get; set; }
    }
}