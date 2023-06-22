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
        private const string DATA_FOLDER_PATH = ".\\Data";
        private const string DATE_FORMAT = "dd-MM-yyyy";
        private const string FILE_FORMAT = ".bin";

        public StatisticView()
        {
            InitializeComponent();
            try
            {
                displayTotalTime();
                displayDataInTable();
                displayTodayInfo();
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void backButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void displayTodayInfo()
        {
            string filePath = DATA_FOLDER_PATH + "\\" + DateTime.Now.ToString(DATE_FORMAT) + FILE_FORMAT;

            if (File.Exists(filePath))
            {
                PomodoroModel todayRecord = PomodoroRecordsStatictic.GetRecordFromFile(DateTime.Now.ToString(DATE_FORMAT) + FILE_FORMAT);
                todayCount.Content = "Today pomodoros: " + todayRecord.TodayCount;
                todayTime.Content = "Today time: " + secondsToFormat(todayRecord.TodayTime);
            }
            else
            {
                todayCount.Content = "Today pomodoros: 0";
                todayTime.Content = "Today time: 0";
            }
        }
        private void displayTotalTime()
        {
            totalTime.Content = "Total time: " + secondsToFormat(PomodoroRecordsStatictic.GetRecordsTotalTime());
        }
        private void displayDataInTable()
        {
            List<RecordItem> records = new List<RecordItem>();
            foreach (string file in Directory.GetFiles(DATA_FOLDER_PATH))
            {
                FileInfo fileInfo = new FileInfo(file);
                PomodoroModel pomodoroModel = PomodoroRecordsStatictic.GetRecordFromFile(fileInfo.Name);
                // add info to list
                records.Add(new SatatisticTableItemModel
                {
                    Date = fileInfo.Name.Replace(".bin", ""),
                    Time = secondsToFormat(pomodoroModel.TodayTime),
                    Count = pomodoroModel.TodayCount.ToString()
                }
                );
            }

            // sort records by date
            records = RecordsSorter.SortItemsDate(records);

            // add new items to datagrid
            foreach (var item in records) daysList.Items.Add(item);
        }
        private string secondsToFormat(int secondsCount)
        {
            int hours = secondsCount / 3600;
            int minutes = (secondsCount % 3600) / 60;
            int seconds = (secondsCount % 3600) % 60;
            return $"{hours} hours {minutes} min {seconds} sec";
        }

        
        public string TotalTime { get; set; }
        public string TodayPomodoros { get; set; }
        public string TodayTime { get; set; }
    }
}
