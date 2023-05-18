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
        // current view model
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        private ViewModelBase? currentViewModel;
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.

        // when the CurrentViewModelChanged has changed event
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        public event Action? CurrentViewModelChanged;
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.

#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        public ViewModelBase? CurrentViewModel
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        {
            get => currentViewModel;
            set 
            {
                if (currentViewModel != value)
                {
                    currentViewModel = value;
                    // raises CurrentViewModelChanged event
                    OnCurrentViewModelChanged();
                }
            }
        }

        /// <summary>
        /// Method that invokes the CurrentViewModelChanged event
        /// when the CurrentViewModelChanged has changed.
        /// </summary>
        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}
