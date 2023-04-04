using System.Windows;
using System.Windows.Input;
using WPF_Control.Views;
using WPF_Control.Views.Chat.Components;
using WPF_Control.Views.User.Components;
using WPF_Library.Commands;
using WPF_Library.ViewModels;

namespace WPF_Control.Navigation
{
    public class MVVM_Navigation : MVVM_Proj
    {
        #region [COMMANDS]

        #region [NAVIGATION]

        #region [MAIN]

        public ICommand MainNav { get; }
        public ICommand GitHub { get; }

        #endregion

        #region [USER]

        public ICommand UserServiceNav { get; }
        public ICommand UserLogServiceNav { get; }
        public ICommand UserAddServiceNav { get; }

        #endregion

        #region [CHAT]

        public ICommand ChatServiceNav { get; }
        public ICommand ChatLogServiceNav { get; }
        public ICommand ChatAddServiceNav { get; }


        #endregion

        #endregion

        #endregion

        #region [COMMANDS_METHODS]

        #region [NAVIGATION]

        /// <summary>
        /// [ShowWindowAndClosePrevious]
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="window"></param>
        private void ShowWindowAndClosePrevious<T>(T window) where T : Window, new()
        {
            Application.Current.MainWindow.Closing += (obj, e) =>
            {
                if (!window.IsActive)
                {
                    Application.Current.MainWindow = window;
                }
            };

            Application.Current.MainWindow.Close();
            window.Show();
        }

        #region [MAIN]

        /// <summary>
        /// [MainNavWindow]
        /// </summary>
        /// <param name="sender"></param>
        private void MainNavWindow(object sender)
        {
            var window = new Main();
            ShowWindowAndClosePrevious(window);
        }

        /// <summary>
        /// [GitHubNavWindow]
        /// </summary>
        /// <param name="sender"></param>
        private void GitHubNavWindow(object sender)
        {
            System.Diagnostics.Process.Start("https://github.com/FL0REN1");
        }

        #endregion

        #region [USER]

        /// <summary>
        /// [UserServiceNavWindow]
        /// </summary>
        /// <param name="sender"></param>
        public void UserServiceNavWindow()
        {
            var window = new UserService();
            ShowWindowAndClosePrevious(window);
        }

        /// <summary>
        /// [UserAddServiceNavWindow]
        /// </summary>
        /// <param name="sender"></param>
        private void UserAddServiceNavWindow(object sender)
        {
            var window = new UserAddService();
            ShowWindowAndClosePrevious(window);
        }

        #endregion

        #region [CHAT]

        /// <summary>
        /// [ChatServiceNavWindow]
        /// </summary>
        /// <param name="sender"></param>
        public void ChatServiceNavWindow()
        {
            var window = new ChatService();
            ShowWindowAndClosePrevious(window);
        }

        /// <summary>
        /// [ChatAddServiceNavWindow]
        /// </summary>
        /// <param name="sender"></param>
        private void ChatAddServiceNavWindow(object sender)
        {
            var window = new ChatAddService();
            ShowWindowAndClosePrevious(window);
        }

        #endregion

        #endregion

        #endregion

        /// <summary>
        /// [CONSTRUCTOR]
        /// </summary>
        public MVVM_Navigation()
        {
            #region [NAVIGATION]

            #region [MAIN]

            MainNav = new BaseCommand(MainNavWindow, _ => true);
            GitHub = new BaseCommand(GitHubNavWindow, _ => true);

            #endregion

            #region [USER]

            UserServiceNav = new BaseCommand((obj) => UserServiceNavWindow(), _ => true);
            UserAddServiceNav = new BaseCommand(UserAddServiceNavWindow, _ => true);

            #endregion

            #region [CHAT]

            ChatServiceNav = new BaseCommand((obj) =>  ChatServiceNavWindow(), _ => true);
            ChatAddServiceNav = new BaseCommand(ChatAddServiceNavWindow, _ => true);

            #endregion

            #endregion
        }
    }
}
