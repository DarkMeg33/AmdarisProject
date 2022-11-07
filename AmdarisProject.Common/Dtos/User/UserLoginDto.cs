using System.ComponentModel.DataAnnotations;

namespace AmdarisProject.Common.Dtos.User
{
    public class UserLoginDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
