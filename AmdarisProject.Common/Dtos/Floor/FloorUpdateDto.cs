using System.ComponentModel.DataAnnotations;
using AmdarisProject.Common.Dtos.Hostel;

namespace AmdarisProject.Common.Dtos.Floor
{
    public class FloorUpdateDto
    {
        [Range(1, Int32.MaxValue)]
        public int FloorNumber { get; set; }

        public bool HasKitchen { get; set; }
        public bool HasWashMachine { get; set; }
        public int HostelId { get; set; }
    }
}
