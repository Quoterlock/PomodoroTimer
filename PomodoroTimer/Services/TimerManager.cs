using System;
using System.Threading;

namespace PomodoroTimer.Services
{
    public class TimerManager
    {
        private Timer timer;

        protected int remainingTime;

        public event Action TimerTick;

        public TimerManager() {
            // none
        }

        /////////// METHODS ///////////
        /// <summary>
        /// Start timer on time method
        /// </summary>
        /// <param name="time">time (seconds)</param>
        public void Start(int time)
        {
            // устанавливаем метод обратного вызова
            TimerCallback timerCallback = new TimerCallback(Count);
            Console.WriteLine("Timer Started...");
            
            // set timer
            remainingTime = time;
            // run timer with this as a object param
            timer = new Timer(timerCallback, this, 0, 1000);
        }

        /// <summary>
        /// Method that is called every timer tick
        /// </summary>
        /// <param name="obj"></param>
        static void Count(object obj)
        {
            // Cast parent object
            TimerManager _this = (TimerManager)obj;

            // reduce time
            _this.remainingTime--;

            // log
            Console.WriteLine("Tick..." + _this.remainingTime);
            
            // if time is 0 -> stop this timer
            if (_this.remainingTime == 0) _this.Stop();
        }

        /// <summary>
        /// Stop timer method
        /// </summary>
        public void Stop()
        {
            timer.Dispose();
        }

        /// <summary>
        /// Method that inform
        /// all event subscribers
        /// about timer tick
        /// </summary>
        private void OnTimerTick()
        {
            TimerTick?.Invoke();
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
                    OnTimerTick(); // alert all subs
                }
            }
        }

    }
}
