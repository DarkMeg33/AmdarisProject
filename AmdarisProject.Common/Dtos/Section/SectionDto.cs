using AmdarisProject.Common.Dtos.Room;

namespace AmdarisProject.Common.Dtos.Section
{
    public class SectionDto
    {
        public int Id { get; set; }
        public int SectionNumber { get; set; }

        public bool HasShower { get; set; }
        public bool HasToiler { get; set; }

        public int FloorId { get; set; }
        public IList<RoomDto> Rooms { get; set; }
    }
}
