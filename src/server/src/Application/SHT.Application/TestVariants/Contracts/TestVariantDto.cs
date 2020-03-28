using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using LinqKit;
using SHT.Application.Common;
using SHT.Common.Utils;
using SHT.Domain.Models.Tests;

namespace SHT.Application.TestVariants.Contracts
{
    [ApiDataContract]
    public class TestVariantDto
    {
        public static readonly Expression<Func<TestVariant, TestVariantDto>> Selector =
            ExpressionUtils.Expand<TestVariant, TestVariantDto>(variant => new TestVariantDto
            {
                Id = variant.Id,
                Name = variant.Name,
                CreatedByName = variant.CreatedBy.Account.Email,
                Questions = variant.Questions.Select(e => TestVariantQuestionDto.Selector.Invoke(e)).ToArray(),
            });

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string CreatedByName { get; set; }

        public IReadOnlyCollection<TestVariantQuestionDto> Questions { get; set; }
    }
}