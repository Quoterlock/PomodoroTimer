using PomodoroTimer.Services;
using PomodoroTimer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
            int time = TimerSingleton.get().RemainingTime;
            if(time <= 0) {
                if(viewModel.isWorkTimer)
                {
                    Statistic.addToDate(
                    new Models.PomodoroModel { TodayTime = viewModel.TimerDuration, TodayCount = 1 }, DateTime.Now.ToString("dd-MM-yyyy") + ".bin");
                }

                Player soundPlayer = new Player();
                soundPlayer.setSong(Properties.Settings.Default.sound);
                try
                {
                    soundPlayer.play();
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            viewModel.CurrentTime = time/60 + ":" + time%60;
        }
    }
}
