using System.ComponentModel.DataAnnotations;

namespace AmdarisProject.Common.Dtos.Section
{
    public class SectionUpdateDto
    {
        [Range(1, Int32.MaxValue)]
        public int SectionNumber { get; set; }

        public bool HasShower { get; set; }
        public bool HasToiler { get; set; }

        public int FloorId { get; set; }
    }
}
