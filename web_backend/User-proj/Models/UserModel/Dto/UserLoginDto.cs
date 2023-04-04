using System.ComponentModel.DataAnnotations;

namespace User_proj.Models.UserModel.Dto
{
    public class UserLoginDto
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
