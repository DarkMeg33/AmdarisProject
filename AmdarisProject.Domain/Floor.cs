namespace AmdarisProject.Domain
{
    public class Floor : BaseEntity
    {
        public int FloorNumber { get; set; }

        public bool HasKitchen { get; set; }
        public bool HasWashMachine { get; set; }

        public int HostelId { get; set; }
        public Hostel Hostel { get; set; }

        public IList<Node> Nodes { get; set; }
    }
}
