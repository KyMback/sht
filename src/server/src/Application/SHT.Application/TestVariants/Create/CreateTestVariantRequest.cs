using SHT.Application.Common;
using SHT.Application.TestVariants.Contracts;

namespace SHT.Application.TestVariants.Create
{
    public class CreateTestVariantRequest : BaseRequest<TestVariantSaveDataDto, CreatedEntityResponse>
    {
        public CreateTestVariantRequest(TestVariantSaveDataDto data)
            : base(data)
        {
        }
    }
}