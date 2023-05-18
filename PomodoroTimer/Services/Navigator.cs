using PomodoroTimer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PomodoroTimer.Services
{
    public class Navigator
    {
        private ViewModelBase? currentViewModel;

        // when the CurrentViewModelChanged has changed event
        public event Action? CurrentViewModelChanged;

        public ViewModelBase? CurrentViewModel
        {
            get => currentViewModel;
            set
            {
                if(currentViewModel != value)
                {
                    currentViewModel = value;
                    OnCurrentViewModelChanged();
                }
            }
        }
    }
}
