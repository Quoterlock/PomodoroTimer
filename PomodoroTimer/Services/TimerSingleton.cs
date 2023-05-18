using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PomodoroTimer.Services
{
    internal sealed class TimerSingleton
    {
        private static TimerManager timerManager;
        public static TimerManager get()
        {
            if(timerManager == null)
            {
                timerManager = new TimerManager();
            }
            return timerManager;
        }
    }
}
