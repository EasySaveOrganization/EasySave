using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using ConsoleDeportee.ExecuteFolder;
using ConsoleDeportee.LanguageFolder;
using Newtonsoft.Json;

namespace ConsoleDeportee.AddWork
{
    public class SaveWorkViewModel : INotifyPropertyChanged
    {

        private NetWorkService _netWorkService;
        public ICommand AddWorkCommand { get; private set; }
        public ICommand ExecuteWorkCommand { get; private set; }
        public ICommand SettingsCommand { get; private set; }

        public event PropertyChangedEventHandler? PropertyChanged;


        // Method to notify when a property changes
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public SaveWorkViewModel()
        {
            //Initialize command
            AddWorkCommand = new RelayCommand(param => NavigateToAddWork(), param => CanNavigate());
            ExecuteWorkCommand = new RelayCommand(param => NavigateToExecuteWork(), param => CanNavigate());
            SettingsCommand = new RelayCommand(param => NavigateToSettings(), param => CanNavigate());
            _netWorkService = new NetWorkService();
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
                { "type", type },
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
    }
}
