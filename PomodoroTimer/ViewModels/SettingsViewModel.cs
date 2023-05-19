using GalaSoft.MvvmLight.Command;
using PomodoroTimer.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PomodoroTimer.ViewModels
{
    internal class SettingsViewModel : ViewModelBase
    {

        private string workTime;
        private string restTime;
        private string longRestTime;
        private string soundPath;

        public SettingsViewModel() {

            soundPath = Properties.Settings.Default.sound;
            workTime = Properties.Settings.Default.workTime.ToString();
            restTime = Properties.Settings.Default.restTime.ToString();
            longRestTime = Properties.Settings.Default.longRestTime.ToString();

            Save = new RelayCommand(saveSettings);
            Back = new NavToHome();
        }

        public string WorkTime
        {
            get { return workTime; }
            set { 
                workTime = value;
                OnPropertyChanged(nameof(WorkTime));
            }
        }

        public string RestTime
        { 
            get { return restTime; } 
            set
            {
                restTime = value;
                OnPropertyChanged(nameof(RestTime));
            } 
        }

        public string LongRestTime 
        {
            get => longRestTime;
            set 
            {
                longRestTime = value;
                OnPropertyChanged(nameof(LongRestTime));
            }
        }

        public string SoundPath
        {
            get => soundPath;
            set
            {
                soundPath = value;
                OnPropertyChanged(nameof(SoundPath));
            }
        }

        public ICommand Save;
        public ICommand Back;
            
        private void saveSettings()
        {
            try
            {
                Properties.Settings.Default.workTime = int.Parse(workTime);
                Properties.Settings.Default.restTime = int.Parse(restTime);
                Properties.Settings.Default.longRestTime = int.Parse(longRestTime);
                Properties.Settings.Default.sound = soundPath;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

    }
}
