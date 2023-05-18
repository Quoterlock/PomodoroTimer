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
            this.viewModel = viewModel;
            TimerSingleton.get().TimerTick += TimerTick;

        }
        public override void Execute(object parameter)
        {
            // log
            Console.WriteLine("Start command...");
            TimerSingleton.get().Start(viewModel.TimerDuration);
        }

        private void TimerTick()
        {
            viewModel.CurrentTime = TimerSingleton.get().RemainingTime;
        }
    }
}
