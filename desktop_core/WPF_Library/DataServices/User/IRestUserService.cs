using System.Collections.ObjectModel;
using System.Threading.Tasks;
using WPF_Library.Models.User;

namespace WPF_Library.DataServices.User
{
    public interface IRestUserService
    {
        Task<ObservableCollection<UserReadModel>> GetAllUsers();
        Task<UserReadModel> GetUserById(int id);
        Task<UserReadModel> CreateUser(UserCreateModel userCreateModel);
        Task ChangeUser(UserChangeModel userChangeModel, int id);
        Task DeleteUser(UserDeleteModel userDeleteModel);
        Task ClearUsers();
    }
}
