namespace AmdarisProject.Common.Dtos.Room
{
    public class RoomDto
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public int BedCount { get; set; }
        public int BedsideTableCount { get; set; }
        public int TableCount { get; set; }
        public bool HasCupboard { get; set; }
        public bool IsRepaired { get; set; }
        public int SectionId { get; set; }
    }
}
