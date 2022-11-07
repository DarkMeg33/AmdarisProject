using AmdarisProject.Common.Dtos.Hostel;
using AmdarisProject.Common.Dtos.Section;

namespace AmdarisProject.Common.Dtos.Floor
{
    public class FloorDto
    {
        public int Id { get; set; }
        public int FloorNumber { get; set; }

        public bool HasKitchen { get; set; }
        public bool HasWashMachine { get; set; }
        public int HostelId { get; set; }
        public IList<SectionDto> Sections { get; set; }
    }
}
