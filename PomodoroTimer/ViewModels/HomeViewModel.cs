using GalaSoft.MvvmLight.Command;
using PomodoroTimer.Commands;
using PomodoroTimer.Views;
using System.Security.RightsManagement;
using System.Windows.Forms;
using System.Windows.Input;

namespace PomodoroTimer.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private int timerDuration;
        private string mode;
        private string currentTime;
        public HomeViewModel() {

            // default values
            currentTime = "00:00";
            timerDuration = 1;
            ModeLabel = "Current mode: None (0 min)";

            // bind commands
            Start = new StartTimer(this);
            Stop = new StopTimer(this);
            ToSetting = new NavToSettings();
            SetWork = new RelayCommand(setWorkTime);
            SetRest = new RelayCommand(setRestTime);
            SetLongRest = new RelayCommand(setLongRestTime);
            ToStats = new RelayCommand(openStats);
            SetCycle = new RelayCommand(setCycleMode);
        }

        /////// PROPERTIES ///////
        public string ModeLabel
        {
            get => mode;
            set
            {
                if(mode != value)
                {
                    mode = value;
                    OnPropertyChanged(nameof(ModeLabel));
                }
            }
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
        public bool isCycleMode { get; set; } 

        /////// COMMANDS ///////
        public ICommand Start { get;  }
        public ICommand Stop { get; }
        public ICommand ToSetting { get; }
        public ICommand ToStats { get; }
        public ICommand SetWork { get; }
        public ICommand SetRest { get; }
        public ICommand SetLongRest { get; }
        public ICommand SetCycle { get; }

        /////// METHODS ///////
        private void setWorkTime()
        {
            timerDuration = Properties.Settings.Default.workTime * 60;
            ModeLabel = "Current mode: Work (" + timerDuration/60 + " min)";
            isWorkTimer = true;
        }

        private void setRestTime()
        {
            timerDuration = Properties.Settings.Default.restTime * 60;
            ModeLabel = "Current mode: Rest (" + timerDuration / 60 + " min)";
            isWorkTimer = false;
        }

        private void setLongRestTime()
        {
            timerDuration = Properties.Settings.Default.longRestTime * 60;
            ModeLabel = "Current mode: Long rest (" + timerDuration / 60 + " min)";
            isWorkTimer = false;
        }

        private void setCycleMode()
        {
            int workTime = Properties.Settings.Default.workTime;
            int restTime = Properties.Settings.Default.restTime;

            ModeLabel = "Current mode: cycle (" + workTime + ":" + restTime + ")";

            timerDuration = workTime * 60;
            isWorkTimer = true;
            isCycleMode = true;
        }

        private void openStats()
        {
            StatisticView window = new StatisticView();
            window.Show();
        }

    }
}
