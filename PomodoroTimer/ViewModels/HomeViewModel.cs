using GalaSoft.MvvmLight.Command;
using PomodoroTimer.Commands;
using PomodoroTimer.Views;
using System.Windows.Input;

namespace PomodoroTimer.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        int timerDuration;

        string currentTime;
        public HomeViewModel() {

            // temp duration
            currentTime = "0:0";
            timerDuration = 1;

            // commands
            Start = new StartTimer(this);
            Stop = new StopTimer(this);
            ToSetting = new NavToSettings();
            SetWork = new RelayCommand(setWorkTime);
            SetRest = new RelayCommand(setRestTime);
            SetLongRest = new RelayCommand(setLongRestTime);
            ToStats = new RelayCommand(openStats);
        }


        public string CurrentTime
        {
            get => currentTime;
            set
            {
                if (currentTime != value)
                {
                    currentTime = value;
                    OnPropertyChanged(nameof(CurrentTime));
                }
            }
        }

        public int TimerDuration 
        {
            get => timerDuration;
            set
            {
                if(timerDuration != value)
                {
                    timerDuration = value;
                    OnPropertyChanged(nameof(TimerDuration));
                }
            }
        }

        public bool isWorkTimer { get; set; }

        public ICommand Start { get;  }
        public ICommand Stop { get; }
        public ICommand ToSetting { get; }
        public ICommand ToStats { get; }
        public ICommand SetWork { get; }
        public ICommand SetRest { get; }
        public ICommand SetLongRest { get; }

        /////// METHODS ///////
        private void setWorkTime()
        {
            timerDuration = Properties.Settings.Default.workTime * 60;
            isWorkTimer = true;
        }

        private void setRestTime()
        {
            timerDuration = Properties.Settings.Default.restTime * 60;
            isWorkTimer = false;
        }

        private void setLongRestTime()
        {
            timerDuration = Properties.Settings.Default.longRestTime * 60;
            isWorkTimer = false;
        }

        private void openStats()
        {
            StatisticView window = new StatisticView();
            window.Show();
        }
    }
}
