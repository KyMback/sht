namespace SHT.Infrastructure.DataAccess.Abstractions
{
    public class PageSettings
    {
        public PageSettings(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }
    }
}