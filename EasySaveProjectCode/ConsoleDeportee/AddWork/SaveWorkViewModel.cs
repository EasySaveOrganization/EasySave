using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using ConsoleDeportee.ExecuteFolder;
using ConsoleDeportee.LanguageFolder;
using Newtonsoft.Json;
using ConsoleDeportee.StatusFolder;

namespace ConsoleDeportee.AddWork
{
    public class SaveWorkViewModel : INotifyPropertyChanged
    {

        private NetWorkService _netWorkService;
        public ICommand AddWorkCommand { get; private set; }
        public ICommand ExecuteWorkCommand { get; private set; }
        public ICommand SettingsCommand { get; private set; }
        public ICommand StatusCommand { get; private set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        //The binding names
        public string BackupName => LanguageManager.GetInstance().Translate("Backup Name");
        public string TargetDirectory => LanguageManager.GetInstance().Translate("Target Directory");
        public string SourceDirectory => LanguageManager.GetInstance().Translate("Source Directory");
        public string BackupType => LanguageManager.GetInstance().Translate("Backup Type");
        public string BackupFormat => LanguageManager.GetInstance().Translate("Backup Format");
        public string BackupCrypt => LanguageManager.GetInstance().Translate("Backup Extension Crypt (.txt,.jpg,.pdf)");
        public string Validate => LanguageManager.GetInstance().Translate("Validate");
        public string ExecuteWork => LanguageManager.GetInstance().Translate("Execute work");
        public string Settings => LanguageManager.GetInstance().Translate("Settings");

        // Method to notify when a property changes
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public SaveWorkViewModel(NetWorkService netWorkService)
        {
            //Initialize command
            AddWorkCommand = new RelayCommand(param => NavigateToAddWork(), param => CanNavigate());
            ExecuteWorkCommand = new RelayCommand(param => NavigateToExecuteWork(), param => CanNavigate());
            SettingsCommand = new RelayCommand(param => NavigateToSettings(), param => CanNavigate());
            StatusCommand = new RelayCommand(param => NavigateToStatus(), param => CanNavigate());
            _netWorkService = netWorkService;
            LanguageManager.LanguageChanged += OnLanguageChanged;
        }

        private void OnLanguageChanged(object sender, EventArgs e)
        {
            OnPropertyChanged(nameof(BackupName));
            OnPropertyChanged(nameof(TargetDirectory));
            OnPropertyChanged(nameof(SourceDirectory));
            OnPropertyChanged(nameof(BackupType));
            OnPropertyChanged(nameof(BackupFormat));
            OnPropertyChanged(nameof(BackupCrypt));
            OnPropertyChanged(nameof(Validate));
            OnPropertyChanged(nameof(ExecuteWork));
            OnPropertyChanged(nameof(Settings));
        }

        //method to send a request
        public async Task AddWork(string name, string target, string source, string type, string extensionFileToCrypt, int logsFormat)
        {
            var request = new Dictionary<string, string>
            {
                { "type", "createBackup" },
                { "name", name },
                { "target", target },
                { "source", source },
                { "BackupType", type },
                { "extensionFileToCrypt", extensionFileToCrypt },
                { "logsFormat", logsFormat.ToString() } 
            };

            try
            {
                var response = await _netWorkService.SendRequest(request);
                var responseMessage = response["response"];
                MessageBox.Show(responseMessage, "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while adding the backup: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        //this will determine if the command can be executed
        private bool CanNavigate()
        {
            return true;
        }


        //Navigation part
        //This method finds the frame and uses it to navigate
        private void NavigateToAddWork()
        {
            // Navigate to the AddWork page
            Application.Current.MainWindow.Content = new AddWorkView();
        }

        private void NavigateToExecuteWork()
        {
            Application.Current.MainWindow.Content = new ExecuteWork();
        }
        private void NavigateToSettings()
        {
            Application.Current.MainWindow.Content = new Settings();
        }

        private void NavigateToStatus()
        {
            Application.Current.MainWindow.Content = new StatusWindow();
        }
    }
}
