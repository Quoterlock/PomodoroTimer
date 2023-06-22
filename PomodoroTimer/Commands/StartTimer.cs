using PomodoroTimer.Services;
using PomodoroTimer.ViewModels;
using System;
using System.Windows;

namespace PomodoroTimer.Commands
{
    internal class StartTimer : CommandBase
    {
        HomeViewModel viewModel;
        int remainingTime;

        public StartTimer(HomeViewModel viewModel) 
        { 
            this.viewModel = viewModel;
            remainingTime = 0;
            TimerSingleton.Get().TimerTick += timerTick;
        }

        public override void Execute(object parameter)
        {
            // try to start timer
            try
            {
                TimerSingleton.Get().start(viewModel.TimerDuration);
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void timerTick()
        {
            remainingTime = TimerSingleton.Get().RemainingTime;

            showCurrentTimeInUI();

            if (remainingTime <= 0) 
            {
                TimerSingleton.Get().stop();

                if(viewModel.isWorkTimer)
                    appendCurrentRecord(viewModel.TimerDuration);

                playSoundNotification();

                if (viewModel.isCycleMode)
                    startNextCycle();
            }
        }

        private void showCurrentTimeInUI()
        {
            int minutes = remainingTime / 60;
            int seconds = remainingTime % 60;
            viewModel.CurrentTime = ((minutes < 10) ? "0" + minutes : minutes) + ":" + ((seconds < 10) ? "0" + seconds : seconds);
        }
        private void appendCurrentRecord(int recordTime)
        {
            PomodoroRecordsStatictic.append(
                new Models.PomodoroModel { TodayTime = recordTime, TodayCount = 1 },
                DateTime.Now.ToString("dd-MM-yyyy") + ".bin");
        }
        private void playSoundNotification()
        {
            try
            {
                Player soundPlayer = new Player();
                soundPlayer.setSoundPath(Properties.Settings.Default.sound);
                soundPlayer.playSelectedSound();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void startNextCycle()
        {
            if (viewModel.isWorkTimer)
            {
                setRestTime();
                this.Execute(null);
            }
            else
            {
                setWorkTime();
                this.Execute(null);
            }
        }
        private void setRestTime()
        {
            int restTime = Properties.Settings.Default.restTime;
            viewModel.TimerDuration = restTime * 60;
            viewModel.isWorkTimer = false;
        }
        private void setWorkTime()
        {
            int workTime = Properties.Settings.Default.workTime;
            viewModel.TimerDuration = workTime * 60;
            viewModel.isWorkTimer = true;
        }
    }
}
