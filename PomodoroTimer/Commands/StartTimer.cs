using PomodoroTimer.Services;
using PomodoroTimer.ViewModels;
using System;
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
            // try to start timer
            try
            {
                TimerSingleton.get().Start(viewModel.TimerDuration);
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Change info in view model after each timer tick
        /// </summary>
        private void TimerTick()
        {
            // get remaining time
            int time = TimerSingleton.get().RemainingTime;
            // if time more or equal than 0
            if(time <= 0) {
                // check timer mode
                if(viewModel.isWorkTimer)
                {
                    // add pomodoro record
                    RecordsManager.addToDate(
                    new Models.PomodoroModel { TodayTime = viewModel.TimerDuration, TodayCount = 1 }, DateTime.Now.ToString("dd-MM-yyyy") + ".bin");
                }

                // play notification setted sound
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
            // show current time
            viewModel.CurrentTime = time/60 + ":" + time%60;
        }
    }
}
