using PersonalBudget.Modules;
using PomodoroTimer.Models;
using PomodoroTimer.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

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

        public StatisticView()
        {
            InitializeComponent();

            // show total time
            totalTime.Content = "Total time: " + secToFormat(RecordsManager.getTotalTime());

            // get all records
            List<DataItemModel> items = new List<DataItemModel>();
            foreach(string file in Directory.GetFiles(".\\Data"))
            {
                // get file
                FileInfo info = new FileInfo(file);
                PomodoroModel model = RecordsManager.getByName(info.Name);
                // add info to list
                items.Add( new DataItemModel {
                    Date = info.Name.Replace(".bin", ""), 
                    Time = secToFormat(model.TodayTime),
                    Count = model.TodayCount.ToString() }
                );
            }

            // sort records by date
            items = Sorter.sortByDate(items);

            // add new items to datagrid
            foreach (var item in items) daysList.Items.Add(item);

            // load today info
            if(File.Exists(".\\Data\\" + DateTime.Now.ToString("dd-MM-yyyy") + ".bin"))
            {
                // get info object
                PomodoroModel today = RecordsManager.getByName(DateTime.Now.ToString("dd-MM-yyyy") + ".bin");
                // show in UI
                todayCount.Content = "Today pomodoros: " + today.TodayCount;
                todayTime.Content = "Today time: " + secToFormat(today.TodayTime);
            }
            else
            {
                // set default values
                todayCount.Content = "Today pomodoros: 0";
                todayTime.Content = "Today time: 0";
            }

        }

        /// <summary>
        /// Convert count of seconds to formar "xx hours xx min xx sec"
        /// </summary>
        /// <param name="secs">seconds count</param>
        /// <returns>formated string</returns>
        private string secToFormat(int secs)
        {
            int h = secs / 3600;
            int min = (secs % 3600) / 60;
            int sec = (secs % 3600) % 60;
            return $"{h} hours {min} min {sec} sec";
        }

        /// <summary>
        /// Class to store data rows
        /// </summary>
        public class DataItemModel
        {
            public string Date { get; set; }
            public string Time { get; set; }
            public string Count { get; set; }
        }

        /// <summary>
        /// Back button click event
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
