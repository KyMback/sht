using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SHT.Domain.Models.Tests;

namespace SHT.Domain.Services.Variants
{
    public interface ITestVariantService
    {
        Task<TestVariant> Create(string name);

        Task LinkQuestions(Guid variantId, IReadOnlyCollection<TestVariantLinkQuestionData> linkQuestionData);
    }
}