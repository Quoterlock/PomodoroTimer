using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PomodoroTimer.Models
{
    [Serializable]
    internal class PomodoroModel
    {
        public int TodayCount { get; set; }
        public int TodayTime { get; set; }

        public override string ToString()
        {
            return "{ TodayCount: " + TodayCount.ToString() + "; TodayTime: " + TodayTime + "; }";
        }
    }
}
