using System.Collections.Generic;
using SHT.Application.Common;

namespace SHT.Application.TestVariants.Contracts
{
    [ApiDataContract]
    public class TestVariantSaveDataDto
    {
        public string Name { get; set; }

        public IReadOnlyCollection<TestVariantQuestionSaveDataDto> Questions { get; set; }
    }
}