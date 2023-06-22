using PomodoroTimer.Services;
using PomodoroTimer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PomodoroTimer.Commands
{
    internal class NavToSettings : CommandBase
    {
        public override void Execute(object parameter)
        {
            SingletonNavigator.get().CurrentViewModel = new SettingsViewModel();
        }
    }
}
