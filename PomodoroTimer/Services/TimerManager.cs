using System;
using System.Threading;

namespace PomodoroTimer.Services
{
    public class TimerManager
    {
        private Timer timer;
        protected int remainingTime;
        public event Action TimerTick;
        private const int TICK_PERIOD = 1000;

        public TimerManager() { }

        /////////// METHODS ///////////
        public void Start(int secondsDuration)
        {
            if(remainingTime <= 0)
            {
                TimerCallback timerCallback = new TimerCallback(count);
                remainingTime = secondsDuration;
                timer = new Timer(timerCallback, this, 0, TICK_PERIOD);
            }
            else
            {
                throw new Exception("Timer is already running!");
            }
        }
        public void Stop()
        {
            if(timer != null)
            {
                timer.Dispose();
                remainingTime = 0;
            }
        }
        private void onTimerTick()
        {
            TimerTick?.Invoke();
        }
        private static void count(object obj)
        {
            TimerManager thisTimer = (TimerManager)obj;
            thisTimer.RemainingTime--;
        }

        ////////// PROPERTIES //////////
        public int RemainingTime
        {
            get => remainingTime;
            set
            {
                if(remainingTime != value)
                {
                    remainingTime = value;
                    onTimerTick(); // alert all subs
                }
            }
        }

    }
}
