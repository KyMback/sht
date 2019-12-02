namespace SHT.Application.Common
{
    [ApiDataContract]
    public class SearchResultBaseFilter
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }
    }
}