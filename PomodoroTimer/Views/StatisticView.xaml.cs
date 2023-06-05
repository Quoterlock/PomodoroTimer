using PomodoroTimer.Models;
using PomodoroTimer.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PomodoroTimer.Views
{
    /// <summary>
    /// Interaction logic for StatisticView.xaml
    /// </summary>
    public partial class StatisticView : Window
    {
        public string TotalTime { get; set; }
        public string TodayPomodoros { get; set; }
        public string TodayTime { get; set; }

        private class DataItemModel 
        {
            public string Sign { get; set; }
            public string Date { get; set; }
            public string Time { get; set; }
            public string Count { get; set; }
        }

        public StatisticView()
        {
            InitializeComponent();
            totalTime.Content = "Total time: " + secToFormat(Statistic.getTotalTime());
            
            //List<PomodoroModel> list = new List<PomodoroModel>();
            // get all records
            foreach(string file in Directory.GetFiles(".\\Data"))
            {
                FileInfo info = new FileInfo(file);
                PomodoroModel model = Statistic.getByName(info.Name);
                daysList.Items.Add( new DataItemModel {
                    Sign = "=", 
                    Date = info.Name.Replace(".bin", ""), 
                    Time = secToFormat(model.TodayTime),
                    Count = model.TodayCount.ToString() }
                );
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private string secToFormat(int secs)
        {
            int h = secs / 3600;
            int min = (secs % 3600) / 60;
            int sec = (secs % 3600) % 60;
            return $"{h} hours, {min} min, {sec} sec";
        }
    }
}
