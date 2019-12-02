using SHT.Application.Common;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Application.Tests.TestSessions.GetList
{
    public class GetAllTestSessionsRequest : BaseRequest<SearchResultBaseFilter, SearchResult<TestSessionListItemDto>>
    {
        public GetAllTestSessionsRequest(SearchResultBaseFilter dataDto)
            : base(dataDto)
        {
        }
    }
}