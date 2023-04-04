using Microsoft.EntityFrameworkCore;

namespace Chat_proj.Models.ChatModel
{
    public class ChatContext : DbContext
    {
        public ChatContext(DbContextOptions<ChatContext> options) : base(options) { }
        public DbSet<Chat> Chats { get; set; }
    }
}
