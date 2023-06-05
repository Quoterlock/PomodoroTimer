using PomodoroTimer.Services;
using PomodoroTimer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PomodoroTimer.Commands
{
    internal class StopTimer : CommandBase
    {
        HomeViewModel viewModel;

        public StopTimer(HomeViewModel viewModel)
        {
            // set view model
            this.viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            // save time
            if (viewModel.isWorkTimer)
            {
                Statistic.addToDate(
                    new Models.PomodoroModel { 
                        TodayTime = viewModel.TimerDuration - TimerSingleton.get().RemainingTime, TodayCount = 1 }, DateTime.Now.ToString("dd-MM-yyyy") + ".bin");
            }
            // stop timer
            TimerSingleton.get().Stop();

            Player soundPlayer = new Player();
            soundPlayer.setSong(Properties.Settings.Default.sound);
            soundPlayer.play();
        }
    }
}
