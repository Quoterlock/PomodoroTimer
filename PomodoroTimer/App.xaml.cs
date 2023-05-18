﻿using PomodoroTimer.Services;
using PomodoroTimer.ViewModels;
using System.Windows;

namespace PomodoroTimer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App() { }

        protected override void OnStartup(StartupEventArgs e)
        {
            // startup view
            SingletonNavigator.Get().CurrentViewModel = new HomeViewModel();

            // load global data
            // load settings

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel()
            };

            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}