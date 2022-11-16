namespace AmdarisProject.Common.Models
{
    public class PaginationRequest
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public SortingRequest SortingRequest { get; set; }
        public FilterRequest FilterRequest { get; set; }
    }
}
