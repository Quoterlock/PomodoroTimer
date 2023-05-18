using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PomodoroTimer.Commands
{
    /// <summary>
    /// Base class for all UI commands
    /// </summary>
    public abstract class CommandBase : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        /// <summary>
        /// Check if command can execute
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public virtual bool CanExecute(object? parameter) => true;

        /// <summary>
        /// Execute command method
        /// </summary>
        /// <param name="parameter"></param>
        public abstract void Execute(object? parameter);

        /// <summary>
        /// Method that invokes the CanExecuteChanged event
        /// when the CanExecute status of a command has changed.
        /// </summary>
        protected void OnCanExecutedChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
