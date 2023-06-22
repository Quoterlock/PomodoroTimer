using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PomodoroTimer.Services
{
    public sealed class SingletonNavigator
    {
        private static Navigator navigator = new Navigator();
        public static Navigator Get()
        {
            if (navigator == null)
                navigator = new Navigator();
            return navigator;
        }
    }
}