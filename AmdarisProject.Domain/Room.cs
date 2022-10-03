namespace AmdarisProject.Domain
{
    public class Room : BaseEntity
    {
        public int RoomNumber { get; set; }
        public int BedCount { get; set; }
        public int BedsideTableCount { get; set; }
        public int TableCount { get; set; }

        public bool HasCupboard { get; set; }
        public bool IsRepaired { get; set; }

        public IList<User> Tenants { get; set; }
    }
}
