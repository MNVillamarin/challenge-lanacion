namespace LaNacion.Application.Parameters
{
    public class PagedResponseParameters
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public PagedResponseParameters()
        {
            this.PageNumber = 1;
            this.PageSize = 10;
        }

        public PagedResponseParameters(int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber < 1 ? 1 : pageNumber;
            this.PageSize = pageSize < 1 ? 1 : pageSize;
        }

    }
}
