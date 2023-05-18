using PomodoroTimer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PomodoroTimer.Commands
{
    internal class StopTimer : CommandBase
    {
        public override void Execute(object parameter)
        {
            TimerSingleton.get().Stop();
        }
    }
}
