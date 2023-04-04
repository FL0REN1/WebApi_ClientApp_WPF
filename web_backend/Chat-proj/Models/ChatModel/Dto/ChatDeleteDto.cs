using System.ComponentModel.DataAnnotations;

namespace Chat_proj.Models.ChatModel.Dto
{
    public class ChatDeleteDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Message { get; set; }
    }
}
