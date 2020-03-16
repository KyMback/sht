using SHT.Application.Common;
using SHT.Application.Common.Tables;
using SHT.Application.Tests.TestSessions.Contracts;

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