using PomodoroTimer.Services;
using PomodoroTimer.ViewModels;
using System;
using System.Windows;

namespace PomodoroTimer.Commands
{
    internal class StopTimer : CommandBase
    {
        HomeViewModel viewModel;

        public StopTimer(HomeViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            if (viewModel.isWorkTimer)
                saveRecord();
            TimerSingleton.Get().Stop();
            resetTimeInUI();
            playSound();
        }
        private void saveRecord()
        {
            PomodoroRecordsStatictic.Append(
                new Models.PomodoroModel { TodayTime = viewModel.TimerDuration - TimerSingleton.Get().RemainingTime, TodayCount = 1 },
                DateTime.Now.ToString("dd-MM-yyyy") + ".bin");
        }
        private void resetTimeInUI()
        {
            viewModel.CurrentTime = "00:00";
        }
        private void playSound()
        {
            try
            {
                Player soundPlayer = new Player();
                soundPlayer.SetSoundPath(Properties.Settings.Default.sound);
                soundPlayer.PlaySelected();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
