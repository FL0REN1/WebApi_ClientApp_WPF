namespace Chat_proj.Models.ChatModel
{
    public interface IChatRep
    {
        bool SaveChanges();

        void ClearChat();
        bool CreateMessage(Chat message);
        bool DeleteMessage(int id);
        bool ChangeMessage(Chat message);
        IEnumerable<Chat> GetAllMessages();
        Chat? GetMessageById(int id);
    }
}
