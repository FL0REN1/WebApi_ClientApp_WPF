using System.Collections.ObjectModel;
using System.Threading.Tasks;
using WPF_Library.Models.Chat;

namespace WPF_Library.DataServices.Chat
{
    public interface IRestChatService
    {
        Task<ObservableCollection<ChatReadModel>> GetAllMessages();
        Task<ChatReadModel> GetChatById(int id);
        Task<ChatReadModel> CreateChat(ChatCreateModel userCreateModel);
        Task ChangeChat(ChatChangeModel userChangeModel);
        Task DeleteChat(ChatDeleteModel userDeleteModel);
        Task ClearChat();
    }
}
