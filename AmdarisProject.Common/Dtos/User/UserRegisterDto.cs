using System.ComponentModel.DataAnnotations;

namespace AmdarisProject.Common.Dtos.User
{
    public class UserRegisterDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
