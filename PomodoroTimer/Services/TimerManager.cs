﻿using System;
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
        public void start(int secondsDuration)
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
        static void count(object obj)
        {
            TimerManager thisTimer = (TimerManager)obj;
            thisTimer.RemainingTime--;
        }
        public void stop()
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
