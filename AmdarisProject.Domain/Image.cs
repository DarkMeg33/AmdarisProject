namespace AmdarisProject.Domain
{
    public class Image : BaseEntity
    {
        public string Path { get; set; }
        public Room Room { get; set; }
    }
}
