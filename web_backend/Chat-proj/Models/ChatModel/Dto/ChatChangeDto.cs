using System.ComponentModel.DataAnnotations;

namespace Chat_proj.Models.ChatModel.Dto
{
    public class ChatChangeDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Message { get; set; }
    }
}
