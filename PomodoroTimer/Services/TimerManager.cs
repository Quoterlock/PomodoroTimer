using PomodoroTimer.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace PomodoroTimer.Services
{
    public class TimerManager
    {
        private Timer timer;

        private int remainingTime;

        public event Action TimerTick;

        public TimerManager() {
        }

        public void Start(int time)
        {
            // устанавливаем метод обратного вызова
            TimerCallback tm = new TimerCallback(Count);
            Console.WriteLine("Timer Started...");
            // создаем таймер
            timer = new Timer(tm, time, 0, 1000);
        }

        public void Stop()
        {
            timer.Dispose();
        }

        static void Count(object obj)
        {
            Console.WriteLine("Tick...");
        }

        private void OnTimerTick()
        {
            TimerTick?.Invoke();
        }

        public int RemainingTime
        {
            get => remainingTime;
            set
            {
                remainingTime = value;
                OnTimerTick();
            }
        }

    }
}
