using SHT.Application.Common;
using SHT.Application.Common.Tables;

namespace SHT.Application.Tests.TestSessions.Students.GetAll
{
    public class GetAllStudentTestSessionsRequest : BaseRequest<SearchResultBaseFilter, TableResult<StudentTestSessionDto>>
    {
        public GetAllStudentTestSessionsRequest(SearchResultBaseFilter data)
            : base(data)
        {
        }
    }
}