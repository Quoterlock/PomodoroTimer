﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PomodoroTimer.Models
{
    public class SatatisticTableItemModel : RecordItem
    {
        public string Date { get; set; }
        public string Time { get; set; }
        public string Count { get; set; }
    }
}
