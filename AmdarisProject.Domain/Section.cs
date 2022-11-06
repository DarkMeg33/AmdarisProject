namespace AmdarisProject.Domain
{
    public class Section : BaseEntity
    {
        public int SectionNumber { get; set; }

        public bool HasShower { get; set; }
        public bool HasToiler { get; set; }

        public int FloorId { get; set; }
        public Floor Floor { get; set; }

        public IList<Room> Rooms { get; set; }
    }
}
