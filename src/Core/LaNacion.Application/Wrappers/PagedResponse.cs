using Application.Wrappers;

namespace LaNacion.Application.Wrappers
{
    public class PagedResponse<T> : Response<T>
    {
        public int PageNumber { get; set; }
        public int TotalRecordCount { get; set; }
        public int PageSize { get; set; }
        public int PageCount { get; set; }

        public PagedResponse(T data, int pageNumber, int totalCount, int pageSize, int pageCount)
        {
            PageNumber = pageNumber;
            TotalRecordCount = totalCount;
            PageSize = pageSize;
            PageCount = pageCount;
            Data = data;
            Message = null;
            Succeeded = true;
            Errors = null;
        }
    }
}
