namespace Chat_proj.Models.ChatModel.Dto
{
    public class ChatReadDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Message { get; set; }
        public DateTime DispatchTime { get; set; }
    }
}
