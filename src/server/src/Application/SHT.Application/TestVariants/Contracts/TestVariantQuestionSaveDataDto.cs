using System;
using SHT.Application.Common;

namespace SHT.Application.TestVariants.Contracts
{
    [ApiDataContract]
    public class TestVariantQuestionSaveDataDto
    {
        public Guid? Id { get; set; }

        public Guid? OriginalQuestionId { get; set; }

        public string Number { get; set; }
    }
}