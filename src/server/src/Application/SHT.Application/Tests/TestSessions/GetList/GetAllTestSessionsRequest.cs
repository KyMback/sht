using SHT.Application.Common;
using SHT.Application.Common.Tables;
using SHT.Infrastructure.DataAccess.Abstractions;

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