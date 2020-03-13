using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SHT.Application.Common;

namespace SHT.Application.TestVariants.Contracts
{
    [ApiDataContract]
    public class TestVariantDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public IReadOnlyCollection<TestVariantQuestionDto> Questions { get; set; }
    }
}