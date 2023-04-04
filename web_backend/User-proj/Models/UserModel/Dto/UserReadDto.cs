using System.ComponentModel.DataAnnotations;

namespace User_proj.Models.UserModel.Dto
{
    public class UserReadDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public bool IsOnline { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public bool IsAdmin { get; set; }
    }
}
