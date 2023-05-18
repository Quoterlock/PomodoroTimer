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
        public ViewModelBase CurrentViewModel => Navigator.CurrentViewModel;
        public MainViewModel()
        {
            Navigator.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
