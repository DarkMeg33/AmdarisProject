namespace AmdarisProject.Domain
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
    }
}
