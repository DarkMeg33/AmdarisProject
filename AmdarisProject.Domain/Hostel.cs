namespace AmdarisProject.Domain
{
    public class Hostel : BaseEntity
    {
        public int HostelNumber { get; set; }

        public IList<Floor> Floors { get; set; }
    }
}
