using System.ComponentModel.DataAnnotations;

namespace User_proj.Models.UserModel.Dto
{
    public class UserDeleteDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
    }
}
