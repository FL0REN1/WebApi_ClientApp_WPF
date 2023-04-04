using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPF_Library.ViewModels
{
    public class Base_MVVM : INotifyPropertyChanged
    {
        #region [BASE MWWM]

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        #endregion
    }
}
