using PomodoroTimer.Services;
using PomodoroTimer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PomodoroTimer.Commands
{
    internal class StartTimer : CommandBase
    {
        HomeViewModel viewModel;

        public StartTimer(HomeViewModel viewModel) 
        { 
            // set view model
            this.viewModel = viewModel;

            // subscribe to timer tick event
            TimerSingleton.get().TimerTick += TimerTick;
        }

        public override void Execute(object parameter)
        {
            // log
            Console.WriteLine("Start command...");

            // start timer
            TimerSingleton.get().Start(viewModel.TimerDuration);
        }

        /// <summary>
        /// Change info in view model after each timer tick
        /// </summary>
        private void TimerTick()
        {
            viewModel.CurrentTime = TimerSingleton.get().RemainingTime;
        }
    }
}
