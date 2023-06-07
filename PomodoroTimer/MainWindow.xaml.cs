﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PomodoroTimer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void dragWindow(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            } catch (Exception ex) 
            {
                System.Windows.MessageBox.Show(ex.Message);
            }

        }

        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult result = System.Windows.Forms.MessageBox.Show("Are you sure you want to close this app?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                Close();
            }
        }

        private void hideBtn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState= WindowState.Minimized;

        }
    }
}
