namespace AmdarisProject.Domain
{
    public class Node : BaseEntity
    {
        public int NodeNumber { get; set; }

        public bool HasShower { get; set; }
        public bool HasToiler { get; set; }

        public int FloorId { get; set; }
        public Floor Floor { get; set; }

        public IList<Room> Rooms { get; set; }
    }
}
