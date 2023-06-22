using PomodoroTimer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PomodoroTimer.Services
{
    /// <summary>
    /// Navigator that contains current view model
    /// </summary>
    public class Navigator
    {
        private ViewModelBase currentViewModel;
        public event Action CurrentViewModelChanged;
        public ViewModelBase CurrentViewModel
        {
            get => currentViewModel;
            set 
            {
                if (currentViewModel != value)
                {
                    currentViewModel = value;
                    OnCurrentViewModelChanged();
                }
            }
        }

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}
