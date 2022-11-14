namespace AmdarisProject.Common.Models
{
    public class PaginationResult<T>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public IList<T> Items { get; set; }
    }
}
