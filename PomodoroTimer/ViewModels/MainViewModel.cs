using PomodoroTimer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PomodoroTimer.ViewModels
{
    internal class MainViewModel : ViewModelBase
    {
        // field that contain current view model (from navigator)
        public ViewModelBase CurrentViewModel => SingletonNavigator.Get().CurrentViewModel;
        public MainViewModel()
        {
            // subscribe to a notification when the current view model changed.
            SingletonNavigator.Get().CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        //////////////// PROPERTIES /////////////////
        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
