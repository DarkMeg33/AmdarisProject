using AmdarisProject.Common.Dtos.Floor;

namespace AmdarisProject.Common.Dtos.Hostel
{
    public class HostelDto
    {
        public int Id { get; set; }
        public int HostelNumber { get; set; }
        public IList<FloorDto> Floors { get; set; }
    }
}
