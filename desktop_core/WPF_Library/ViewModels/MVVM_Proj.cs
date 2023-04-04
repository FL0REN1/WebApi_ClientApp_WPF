using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Threading;
using WPF_Library.Commands;
using WPF_Library.DataServices.Chat;
using WPF_Library.DataServices.User;
using WPF_Library.Models.Chat;
using WPF_Library.Models.User;

namespace WPF_Library.ViewModels
{
    public class MVVM_Proj : Base_MVVM
    {
        #region [DATA]

        private DateTime _currentTime = DateTime.Now;
        public DateTime CurrentTime
        {
            get { return _currentTime; }
            set
            {
                _currentTime = value;
                OnPropertyChanged();
            }
        }

        #region [USER]

        private ObservableCollection<UserReadModel> _users;
        public ObservableCollection<UserReadModel> users
        {
            get => _users;
            set { _users = value; OnPropertyChanged(); }
        }
        public object SelectedUser { get; set; }

        #region [INITIAL]

        public RestUserService _userService = new RestUserService();

        #endregion

        #region [CREATE]

        public UserCreateModel _userCreateModel = new UserCreateModel();

        #endregion

        #region [CHANGE]

        public UserChangeModel _userChangeModel = new UserChangeModel();

        #endregion

        #region [DELETE]

        public UserDeleteModel _userDeleteModel = new UserDeleteModel();

        #endregion

        #endregion

        #region [CHAT]

        private ObservableCollection<ChatReadModel> _chats;
        public ObservableCollection<ChatReadModel> chats
        {
            get => _chats;
            set { _chats = value; OnPropertyChanged(); }
        }
        public object SelectedChat { get; set; }
        public ChatReadModel SelectedChatRead = new ChatReadModel();

        #region [INITIAL]

        public IRestChatService _chatService = new RestChatService();

        #endregion

        #region [CREATE]

        private ChatCreateModel _chatCreateModel = new ChatCreateModel();

        #endregion

        #region [CHANGE]

        private ChatChangeModel _chatChangeModel = new ChatChangeModel();

        #endregion

        #region [DELETE]

        public ChatDeleteModel _chatDeleteModel = new ChatDeleteModel();

        #endregion

        #endregion

        #endregion

        #region [COMMANDS]

        #region [INITIAL]

        public ICommand CommandLoad_userService { get; }
        public ICommand CommandLoad_chatService { get; }

        #endregion

        #region [CREATE]

        public ICommand CommandCreate_userService { get; }
        public ICommand CommandCreate_chatService { get; }

        #endregion

        #region [CHANGE]

        public ICommand CommandChange_userService { get; }
        public ICommand CommandChange_chatService { get; }

        #endregion

        #region [DELETE]

        public ICommand CommandDelete_userService { get; }
        public ICommand CommandDelete_chatService { get; }

        #endregion

        #region [CLEAR_ALL]

        public ICommand CommandClearAll_userService { get; }
        public ICommand CommandClearAll_chatService { get; }

        #endregion

        #endregion

        #region [COMMANDS_METHODS]

        #region [INITIAL]

        /// <summary>
        /// [Load_userService]
        /// </summary>
        /// <param name="sender"></param>
        private async void Load_userService(object sender)
        {
            users = await _userService.GetAllUsers();
        }

        /// <summary>
        /// [Load_chatService]
        /// </summary>
        /// <param name="sender"></param>
        private async void Load_chatService(object sender)
        {
            chats = await _chatService.GetAllMessages();
        }
        /// <summary>
        /// [Timer_Tick]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            CurrentTime = DateTime.Now;
        }

        #endregion

        #region [CREATE]

        /// <summary>
        /// [Create_userService]
        /// </summary>
        /// <param name="userCreateModel"></param>
        private async void Create_userService(UserCreateModel userCreateModel)
        {
            var userModel = await _userService.CreateUser(userCreateModel);
            users.Add(userModel);
        }

        /// <summary>
        /// [Create_chatService]
        /// </summary>
        /// <param name="chatCreateModel"></param>
        private async void Create_chatService(ChatCreateModel chatCreateModel)
        {
            var chatModel = await _chatService.CreateChat(chatCreateModel);
            chats.Add(chatModel);
        }

        #endregion

        #region [CHANGE]

        /// <summary>
        /// [Change_userService]
        /// </summary>
        /// <param name="userChangeModel"></param>
        private async void Change_userService()
        {
            var selectedUserIndex = users.IndexOf((UserReadModel)SelectedUser);
            var selectedUser = users[selectedUserIndex];
            _userChangeModel.id = selectedUser.id;
            _userChangeModel.username = selectedUser.username;
            _userChangeModel.login = selectedUser.login;
            _userChangeModel.password = selectedUser.password;
            await _userService.ChangeUser(_userChangeModel, _userChangeModel.id);
        }

        /// <summary>
        /// [Change_chatService]
        /// </summary>
        /// <param name="chatChangeModel"></param>
        private async void Change_chatService()
        {
            var selectedChatIndex = chats.IndexOf((ChatReadModel)SelectedChat);
            var selectedChat = chats[selectedChatIndex];
            _chatChangeModel.id = selectedChat.id;
            _chatChangeModel.username = selectedChat.username;
            _chatChangeModel.message = selectedChat.message;
            await _chatService.ChangeChat(_chatChangeModel);
        }

        #endregion

        #region [DELETE]

        /// <summary>
        /// [Delete_userService]
        /// </summary>
        /// <param name="userDeleteModel"></param>
        private async void Delete_userService()
        {
            var selectedUserIndex = users.IndexOf((UserReadModel)SelectedUser);
            var selectedUser = users[selectedUserIndex];
            _userDeleteModel.id = selectedUser.id;
            _userDeleteModel.username = selectedUser.username;
            await _userService.DeleteUser(_userDeleteModel);
            users.RemoveAt(selectedUserIndex);
        }

        /// <summary>
        /// [Delete_chatService]
        /// </summary>
        /// <param name="chatDeleteModel"></param>
        private async void Delete_chatService()
        {
            var selectedChatIndex = chats.IndexOf((ChatReadModel)SelectedChat);
            var selectedChat = chats[selectedChatIndex];
            _chatDeleteModel.id = selectedChat.id;
            _chatDeleteModel.message = selectedChat.message;
            await _chatService.DeleteChat(_chatDeleteModel);
            chats.RemoveAt(selectedChatIndex);
        }

        #endregion

        #region [CLEAR_ALL]

        /// <summary>
        /// [CLEAR_ALL_USER_SERVICE]
        /// </summary>
        private async void ClearAll_userService()
        {
            await _userService.ClearUsers();
            users.Clear();
        }

        /// <summary>
        /// [CLEAR_ALL_CHAT_SERVICE]
        /// </summary>
        private async void ClearAll_chatService()
        {
            await _chatService.ClearChat();
            chats.Clear();
        }

        #endregion

        #endregion

        /// <summary>
        /// [CONTRUCTOR]
        /// </summary>
        public MVVM_Proj()
        {
            var timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Start();
            #region [INITIAL]

            CommandLoad_userService = new BaseCommand(Load_userService, _ => true);
            CommandLoad_chatService = new BaseCommand(Load_chatService, _ => true);

            #endregion

            #region [CREATE]

            CommandCreate_userService = new BaseCommand((obj) => Create_userService(_userCreateModel), _ => true); 
            CommandCreate_chatService = new BaseCommand((obj) => Create_chatService(_chatCreateModel), _ => true);

            #endregion

            #region [CHANGE]

            CommandChange_userService = new BaseCommand((obj) => Change_userService(), _ => SelectedUser != null);
            CommandChange_chatService = new BaseCommand((obj) => Change_chatService(), _ => SelectedChat != null);

            #endregion

            #region [DELETE]

            CommandDelete_userService = new BaseCommand((obj) => Delete_userService(), _ => SelectedUser != null);
            CommandDelete_chatService = new BaseCommand((obj) => Delete_chatService(), _ => SelectedChat != null);

            #endregion

            #region [CLEAR_ALL]

            CommandClearAll_userService = new BaseCommand((obj) => ClearAll_userService(), _ => true);
            CommandClearAll_chatService = new BaseCommand((obj) => ClearAll_chatService(), _ => true);

            #endregion
        }
    }
}
