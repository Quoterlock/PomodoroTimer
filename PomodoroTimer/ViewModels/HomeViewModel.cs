using PomodoroTimer.Commands;
using PomodoroTimer.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PomodoroTimer.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        int timerDuration;

        int currentTime;
        public HomeViewModel() {
            timerDuration = 5;
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
