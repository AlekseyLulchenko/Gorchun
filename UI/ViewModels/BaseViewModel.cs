using System.Runtime.CompilerServices;
using System.ComponentModel;
using Gorchun.UI.Commands;
using System.Windows;

namespace Gorchun.UI.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public RelayCommand CloseWindowCommand { get; set; }

        protected abstract string CurrentWindowName { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        public BaseViewModel()
        {
            CloseWindowCommand = new RelayCommand(CloseWindow, CanCloseWindow);
        }

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public virtual void CloseWindow(object parameter)
        {
            if (string.IsNullOrWhiteSpace(CurrentWindowName)) { return; }

            foreach (Window window in Application.Current.Windows)
            {
                if (window.Name == CurrentWindowName) { window.Close(); }
            }
        }

        public virtual bool CanCloseWindow(object parameter)
        {
            return true;
        }
    }
}
