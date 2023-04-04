using MaterialDesignColors.Recommended;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using WPF_Control.Navigation;
using WPF_Library.Commands;
using WPF_Library.Models.Chat;
using WPF_Library.Models.User;

namespace WPF_Control.Add
{
    public class MVVM_Add : MVVM_Navigation, IDataErrorInfo
    {
        #region [DATA]

        #region [USER]

        private string _username;
        private int _age;
        private string _login;
        private string _password;
        private bool _isAdmin;

        public string Username
        {
            get => _username;
            set { _username = value; OnPropertyChanged(); }
        }
        public int Age
        {
            get => _age;
            set { _age = value; OnPropertyChanged(); }
        }
        public string Login
        {
            get => _login;
            set { _login = value; OnPropertyChanged(); }
        }
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }
        public bool IsAdmin
        {
            get => _isAdmin;
            set { _isAdmin = value; OnPropertyChanged(); }
        }

        #endregion

        #region [CHAT]

        private string _usernameChat;
        private string _message;
        private DateTime _dispatchTime;

        public string UsernameChat
        {
            get => _usernameChat;
            set
            {
                _usernameChat = value;
                OnPropertyChanged();
            }
        }
        public string Message
        {
            get => _message;
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }
        public DateTime DispatchTime
        {
            get => _dispatchTime;
            set
            {
                _dispatchTime = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public string this[string columnName]
        {
            get
            {
                string result = null;

                switch (columnName)
                {
                    case nameof(Username):
                        if (string.IsNullOrEmpty(Username))
                        {
                            result = "Username is required";
                        }
                        break;
                    case nameof(Age):
                        if (Age < 18 || Age > 99)
                        {
                            result = "Age must be between 18 and 99";
                        }
                        break;
                    case nameof(Login):
                        if (string.IsNullOrEmpty(Login))
                        {
                            result = "Login is required";
                        }
                        break;
                    case nameof(Password):
                        if (string.IsNullOrEmpty(Password))
                        {
                            result = "Password is required";
                        }
                        break;
                    case nameof(UsernameChat):
                        if (string.IsNullOrEmpty(UsernameChat))
                        {
                            result = "Username is required";
                        }
                        break;
                    case nameof(Message):
                        if (string.IsNullOrEmpty(Message))
                        {
                            result = "Message is required";
                        }
                        break;
                }
                return result;
            }
        }
        public string Error => null;

        #endregion

        #region [COMMANDS]

        #region [SUBMIT]

        public ICommand CommandSubmit_userService { get; }
        public ICommand CommandSubmit_chatService { get; }

        #endregion

        #endregion

        #region [COMMANDS_METHODS]

        #region [SUBMIT]

        /// <summary>
        /// [Add_userService]
        /// </summary>
        /// <param name="sender"></param>
        private async void Add_userService()
        {
            UserCreateModel model = new UserCreateModel()
            {
                username = Username,
                age = Age,
                isOnline = false,
                login = Login,
                password = Password,
                isAdmin = IsAdmin
            };
            var userExists = users.FirstOrDefault(i => i.username == Username || i.login == Login || i.password == Password);
            if (userExists == null)
            {
                await _userService.CreateUser(model);
                UserServiceNavWindow();
            }
            else MessageBox.Show("User already exists in our DB");
        }

        /// <summary>
        /// [Add_chatService]
        /// </summary>
        /// <param name="sender"></param>
        private async void Add_chatService()
        {
            ChatCreateModel model = new ChatCreateModel()
            {
                username = UsernameChat,
                message = Message,
                dispatchTime = DateTime.Now
            };
            var chatExists = chats.FirstOrDefault(i => i.username == Username);
            if (chatExists == null)
            {
                await _chatService.CreateChat(model);
                ChatServiceNavWindow();
            }
            else MessageBox.Show("We don't have such a user in our DB");
        }

        #endregion

        #endregion

        /// <summary>
        /// [CONSTRUCTOR]
        /// </summary>
        public MVVM_Add()
        {
            #region [CREATE]

            CommandSubmit_userService = new BaseCommand((obj) => Add_userService(), _ => true);
            CommandSubmit_chatService = new BaseCommand((obj) => Add_chatService(), _ => true);

            #endregion
        }
    }
}
