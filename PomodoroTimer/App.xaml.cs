using PomodoroTimer.Services;
using PomodoroTimer.ViewModels;
using System.Runtime.InteropServices;
using System;
using System.Windows;
using System.Windows.Controls;

namespace PomodoroTimer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    /// 
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

            // set start window size 250x200
            MainWindow.Width = 250;
            MainWindow.Height = 200;
            // open window
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
