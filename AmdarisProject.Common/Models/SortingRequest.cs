namespace AmdarisProject.Common.Models
{
    public class SortingRequest
    {
        public string ColumnName { get; set; }
        public SortDirection SortDirection { get; set; } = SortDirection.Ascending;
    }
}
