using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using EasySaveProject_V2.ExecuteFolder;
using EasySaveProject_V2.LanguageFolder;
using EasySaveProject_V2.AddWork;
using EasySaveProject_V2.StatusFolder;

namespace EasySaveProject_V2.AddWork
{
    public class SaveWorkViewModel : INotifyPropertyChanged
    {
        private WorkListService workListService = new WorkListService();
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

        public SaveWorkViewModel()
        {
            //Initialize command
            AddWorkCommand = new RelayCommand(param => NavigateToAddWork(), param => CanNavigate());
            ExecuteWorkCommand = new RelayCommand(param => NavigateToExecuteWork(), param => CanNavigate());
            SettingsCommand = new RelayCommand(param => NavigateToSettings(), param => CanNavigate());
            StatusCommand = new RelayCommand(param => NavigateToStatus(), param => CanNavigate());
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

        public void AddWork(string name, string target, string source, string type, string extenstionFileToCrypt, int logsFormat)
        {
            SaveWorkModel saveWorkModel = new SaveWorkModel(name, target, source, type, extenstionFileToCrypt, logsFormat);
            // Initialiser les propriétés de saveWorkModel avec les données nécessaires
            try
            {
                // Ajouter le travail à la liste via le service
                workListService.AddWork(saveWorkModel);
            }
            catch (InvalidOperationException ex)
            {
                //Console.WriteLine(ex.Message);
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
