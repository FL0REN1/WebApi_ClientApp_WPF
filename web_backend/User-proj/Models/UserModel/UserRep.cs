using System;
using User_proj.Models.UserModel.Dto;

namespace User_proj.Models.UserModel
{
    public class UserRep : IUserRep
    {
        #region [DATA]

        private readonly UserContext _context;

        #endregion

        /// <summary>
        /// [UserRep Constructor]
        /// </summary>
        /// <param name="context"></param>
        public UserRep(UserContext context)
        {
            _context = context;
        }

        #region [INTERFACE IMPLEMENTATION]

        /// <summary>
        /// [CREATE]
        /// </summary>
        /// <param name="user"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public bool CreateUser(User user)
        {
            if (user == null)
            {
                string message = "[X] Failed to create user because it is empty";
                UserRabbitMQ.UserErrorMQ.SendMessage(message);
                return false;
            }
            _context.Users.Add(user);
            return true;
        }

        /// <summary>
        /// [DELETE]
        /// </summary>
        /// <param name="user"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public bool DeleteUser(int id)
        {
            User? user = _context.Users.FirstOrDefault(m => m.Id == id);
            if (user == null)
            {
                string message = "[X] Failed to delete user because it is empty";
                UserRabbitMQ.UserErrorMQ.SendMessage(message);
                return false;
            }
            _context.Users.Remove(user);
            return true;
        }

        /// <summary>
        /// [CHANGE_USER]
        /// </summary>
        /// <param name="user"></param>
        /// <param name="id"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public bool ChangeUser(User user, int id)
        {
            User? userModel = _context.Users.FirstOrDefault(m => m.Id == id);
            if (userModel == null)
            {
                string message = "[X] Failed to change user because it is empty";
                UserRabbitMQ.UserErrorMQ.SendMessage(message);
                return false;
            }
            userModel.Username = user.Username;
            userModel.Login = user.Login;
            userModel.Password = user.Password;
            return true;
        }

        /// <summary>
        /// [CLEAR_USERS]
        /// </summary>
        /// <returns></returns>
        public bool ClearUsers()
        {
            _context.Users.RemoveRange(_context.Users);
            return true;
        }

        /// <summary>
        /// [CHANGE_USER_STATUS]
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isOnline"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public bool ChangeUserStatus(int id, bool isOnline)
        {
            User? user = _context.Users.FirstOrDefault(m => m.Id == id);
            if (user == null)
            {
                string message = "[X] Failed to change user status, because user is empty";
                UserRabbitMQ.UserErrorMQ.SendMessage(message);
                return false;
            }
            user.IsOnline = isOnline;
            return true;
        }
        
        /// <summary>
        /// [GET_USER_BY_LOGIN_AND_PASSWORD]
        /// </summary>
        /// <param name="userLoginDto"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public User? GetUserByLoginAndPassword(UserLoginDto userLoginDto)
        {
            User? user = _context.Users.FirstOrDefault(i => i.Login == userLoginDto.Login && i.Password == userLoginDto.Password);
            if (user == null)
            {
                string message = $"[X] Failed to found user login: [{userLoginDto.Login}], and password: [{userLoginDto.Password}]";
                UserRabbitMQ.UserErrorMQ.SendMessage(message);
                return null;
            }
            return user;
        }

        /// <summary>
        /// [GET_ALL]
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        /// <summary>
        /// [GET_BY_ID]
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public User? GetUserById(int id)
        {
            User? IdUser = _context.Users.FirstOrDefault(x => x.Id == id);
            if (IdUser == null)
            {
                string message = $"[X] DB: [User], has no ID: [{id}]";
                UserRabbitMQ.UserErrorMQ.SendMessage(message);
                return null;
            }
            return IdUser;
        }

        /// <summary>
        /// [SAVE_CHANGES]
        /// </summary>
        /// <returns></returns>
        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        #endregion
    }
}
