using Microsoft.AspNetCore.Identity;

namespace AmdarisProject.Domain.Identity
{
    public class User : IdentityUser<int>
    {
        public int? RoomId { get; set; }
        public Room Room { get; set; }
    }
}
