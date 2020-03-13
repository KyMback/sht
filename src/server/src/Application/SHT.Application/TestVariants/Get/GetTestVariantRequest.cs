using System;
using SHT.Application.Common;
using SHT.Application.TestVariants.Contracts;

namespace SHT.Application.TestVariants.Get
{
    public class GetTestVariantRequest : BaseRequest<Guid, TestVariantDto>
    {
        public GetTestVariantRequest(Guid data)
            : base(data)
        {
        }
    }
}