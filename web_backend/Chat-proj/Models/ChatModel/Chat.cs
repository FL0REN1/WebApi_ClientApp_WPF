using System.ComponentModel.DataAnnotations;

namespace Chat_proj.Models.ChatModel
{
    /// <summary>
    /// [dbo.Chat === Chat]
    /// </summary>
    public class Chat
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Message { get; set; }
        [Required]
        public DateTime DispatchTime { get; set; }
    }
}
