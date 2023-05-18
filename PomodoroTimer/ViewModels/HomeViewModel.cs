using PomodoroTimer.Commands;
using System.Windows.Input;

namespace PomodoroTimer.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        int timerDuration;

        int currentTime;
        public HomeViewModel() {

            // temp duration
            timerDuration = 5;
   
            // commands
            Start = new StartTimer(this);
            Stop = new StopTimer();
        }


        public int CurrentTime
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

        public ICommand Start { get;  }
        public ICommand Stop { get; }
    }
}
