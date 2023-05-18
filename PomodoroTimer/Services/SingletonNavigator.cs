using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PomodoroTimer.Services
{
    /// <summary>
    /// Singleton pattern for Navigation class.
    /// sealed (cannot be inherited outside of the assembly).
    /// </summary>
    public sealed class SingletonNavigator
    {
        private static Navigator navigator = new Navigator();

        /// <summary>
        /// Get reference to Navigatior
        /// </summary>
        /// <returns>reference to Navigatior</returns>
        public static Navigator Get()
        {
            // if still not created -> create
            if (navigator == null)
                navigator = new Navigator();
            return navigator;
        }
    }
}