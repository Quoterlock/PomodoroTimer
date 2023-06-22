using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using PomodoroTimer.Commands;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Forms;
using OpenFileDialog = System.Windows.Forms.OpenFileDialog;

namespace PomodoroTimer.ViewModels
{
    internal class SettingsViewModel : ViewModelBase
    {

        private string workTime;
        private string restTime;
        private string longRestTime;
        private string soundPath;

        public SettingsViewModel() {
            getValuesFromSettings();

            // bind commands
            Save = new RelayCommand(saveSettings);
            ChooseFile = new RelayCommand(selectSongPath);
            Back = new NavToHome();
        }

        ///////// PROPERTIES ////////
        public string WorkTime
        {
            get { return workTime; }
            set { 
                workTime = value;
                OnPropertyChanged(nameof(WorkTime));
            }
        }

        public string RestTime
        { 
            get { return restTime; } 
            set
            {
                restTime = value;
                OnPropertyChanged(nameof(RestTime));
            } 
        }

        public string LongRestTime 
        {
            get => longRestTime;
            set 
            {
                longRestTime = value;
                OnPropertyChanged(nameof(LongRestTime));
            }
        }

        public string SoundPath
        {
            get => soundPath;
            set
            {
                soundPath = value;
                OnPropertyChanged(nameof(SoundPath));
            }
        }

        ///////// COMMANDS ////////
        public ICommand Save { get; }
        public ICommand Back { get; }
        public ICommand ChooseFile { get; }

        ///////// METHODS ////////

        private void saveSettings()
        {
            try
            {
                saveCurrentSettingsAsDefault();
                System.Windows.MessageBox.Show("Saved!");
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }           
        }
        private void saveCurrentSettingsAsDefault()
        {
            Properties.Settings.Default.workTime = int.Parse(workTime);
            Properties.Settings.Default.restTime = int.Parse(restTime);
            Properties.Settings.Default.longRestTime = int.Parse(longRestTime);
            Properties.Settings.Default.sound = soundPath;
            Properties.Settings.Default.Save();
        }
        private void selectSongPath()
        {
            try
            {
                SoundPath = selectFile();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }

        }
        private string selectFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = ".\\Sounds";
            openFileDialog.Filter = "song(*.wav)|*.wav|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
                return openFileDialog.FileName;
            else
                throw new Exception("File selection error!");
        }
        private void getValuesFromSettings()
        {
            soundPath = Properties.Settings.Default.sound;
            workTime = Properties.Settings.Default.workTime.ToString();
            restTime = Properties.Settings.Default.restTime.ToString();
            longRestTime = Properties.Settings.Default.longRestTime.ToString();
        }

    }
}
