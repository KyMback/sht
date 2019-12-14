using SHT.Application.Common;
using SHT.Application.Common.Tables;

namespace SHT.Application.Tests.TestSessions.GetList
{
    public class GetAllTestSessionsRequest : BaseRequest<SearchResultBaseFilter, TableResult<TestSessionListItemDto>>
    {
        public GetAllTestSessionsRequest(SearchResultBaseFilter data)
            : base(data)
        {
        }
    }
}