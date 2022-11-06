namespace AmdarisProject.Common.Dtos.Floor
{
    public class FloorDto
    {
        public int Id { get; set; }
        public int FloorNumber { get; set; }

        public bool HasKitchen { get; set; }
        public bool HasWashMachine { get; set; }
    }
}
