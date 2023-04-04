using System.ComponentModel.DataAnnotations;

namespace User_proj.Models.UserModel.Dto
{
    public class UserChangeDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
    }
}