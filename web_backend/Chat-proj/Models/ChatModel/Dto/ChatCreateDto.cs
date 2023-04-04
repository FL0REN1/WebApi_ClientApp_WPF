using System.ComponentModel.DataAnnotations;

namespace Chat_proj.Models.ChatModel.Dto
{
    public class ChatCreateDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Message { get; set; }
        [Required]
        public DateTime DispatchTime { get; set; }
    }
}
