using SHT.Application.Common;
using SHT.Application.Common.Tables;

namespace SHT.Application.TestVariants.GetList
{
    public class GetTestVariantsListRequest : BaseRequest<SearchResultBaseFilter, TableResult<TestVariantListItemDto>>
    {
        public GetTestVariantsListRequest(SearchResultBaseFilter data)
            : base(data)
        {
        }
    }
}