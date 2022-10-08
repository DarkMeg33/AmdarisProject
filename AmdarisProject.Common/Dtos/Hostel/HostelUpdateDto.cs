using System.ComponentModel.DataAnnotations;

namespace AmdarisProject.Common.Dtos.Hostel
{
    public class HostelUpdateDto
    {
        [Range(1, Int32.MaxValue)]
        public int HostelNumber { get; set; }
    }
}
