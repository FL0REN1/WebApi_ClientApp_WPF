using User_proj.Models.UserModel.Dto;

namespace User_proj.Models.UserModel
{
    public interface IUserRep
    {
        bool SaveChanges();

        bool CreateUser(User user);
        bool DeleteUser(int id);
        bool ChangeUser(User user, int id);
        bool ClearUsers();
        bool ChangeUserStatus(int id, bool isOnline);
        User? GetUserByLoginAndPassword(UserLoginDto userLoginDto);
        IEnumerable<User> GetAllUsers();
        User? GetUserById(int id);
    }
}
