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

            // show current time in UI
            int minutes = time / 60;
            int seconds = time % 60;
            viewModel.CurrentTime = ((minutes < 10) ? "0" + minutes : minutes) + ":" + ((seconds < 10) ? "0" + seconds : seconds);

            // if time runned out
            if (time <= 0) 
            {
                TimerSingleton.get().Stop();

                // if it is work timer
                if(viewModel.isWorkTimer)
                {
                    // add pomodoro record
                    RecordsManager.addToDate(
                    new Models.PomodoroModel { TodayTime = viewModel.TimerDuration, TodayCount = 1 }, DateTime.Now.ToString("dd-MM-yyyy") + ".bin");
                }

                // try play notification sound
                Player soundPlayer = new Player();
                soundPlayer.setSong(Properties.Settings.Default.sound);
                try
                {
                    soundPlayer.play();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                // if it is cycle mode
                if (viewModel.isCycleMode)
                {
                    int workTime = Properties.Settings.Default.workTime;
                    int restTime = Properties.Settings.Default.restTime;

                    //viewModel.ModeLabel = "Current mode: cycle (" + workTime + ":" + restTime + ")";
                    
                    // start new timer
                    if (viewModel.isWorkTimer)
                    {
                        // set rest timer
                        viewModel.TimerDuration = restTime * 60;
                        viewModel.isWorkTimer = false;
                        this.Execute(null);
                    }
                    else
                    {
                        // set work timer
                        viewModel.TimerDuration = workTime * 60;
                        viewModel.isWorkTimer = true;
                        this.Execute(null);
                    }
                }
            }
        }
    }
}
