using SHT.Application.Common;
using SHT.Application.Common.Tables;

namespace SHT.Application.Tests.StudentsTestSessions.GetAll
{
    public class GetAllStudentTestSessionsRequest : BaseRequest<SearchResultBaseFilter, TableResult<StudentTestSessionListItemDto>>
    {
        public GetAllStudentTestSessionsRequest(SearchResultBaseFilter data)
            : base(data)
        {
        }
    }
}