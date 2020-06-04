using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using LinqKit;
using SHT.Application.Files.Contracts;
using SHT.Common.Utils;
using SHT.Domain.Models.Tests;
using SHT.Domain.Models.TestSessions.Variants.Questions;

namespace SHT.Application.Tests.TestSessions.Contracts
{
    public class TestSessionVariantQuestionDto
    {
        public static readonly Expression<Func<TestSessionVariantQuestion, TestSessionVariantQuestionDto>> Selector =
            ExpressionUtils.Expand<TestSessionVariantQuestion, TestSessionVariantQuestionDto>(
                e => new TestSessionVariantQuestionDto
                {
                    Id = e.Id,
                    Name = e.Name,
                    Order = e.Order,
                    Type = e.Type,
                    TestSessionVariantId = e.TestSessionVariantId,
                    SourceQuestionId = e.SourceQuestionId,
                    FreeTextQuestion = e.FreeTextQuestion != null ? TestSessionVariantFreeTextQuestionDto.Selector.Invoke(e.FreeTextQuestion) : null,
                    ChoiceQuestion = e.ChoiceQuestion != null ? TestSessionVariantChoiceQuestionDto.Selector.Invoke(e.ChoiceQuestion) : null,
                    Images = e.Images.Select(f => FileInfoDto.Selector.Invoke(f.File)).ToArray(),
                });

        public Guid Id { get; set; }

        public int? Order { get; set; }

        public string Name { get; set; }

        public QuestionType Type { get; set; }

        public Guid TestSessionVariantId { get; set; }

        public Guid? SourceQuestionId { get; set; }

        public IReadOnlyCollection<FileInfoDto> Images { get; set; }

        public TestSessionVariantFreeTextQuestionDto FreeTextQuestion { get; set; }

        public TestSessionVariantChoiceQuestionDto ChoiceQuestion { get; set; }
    }
}