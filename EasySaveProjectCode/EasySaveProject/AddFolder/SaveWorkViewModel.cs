using System;
using System.Windows.Input;
using EasySaveProject.ExecuteFolder;
using EasySaveProject.LanguageFolder;
using EasySaveProject.SaveWork;
using System.Windows;
using System.ComponentModel;

namespace EasySaveProject.AddFolder
{
    public class SaveWorkViewModel : INotifyPropertyChanged
    {
        private WorkListService workListService = new WorkListService();
        public ICommand AddWorkCommand { get; private set; }
        public ICommand ExecuteWorkCommand { get; private set; }
        public ICommand SettingsCommand { get; private set; }
        
        public event PropertyChangedEventHandler PropertyChanged;

        //The binding names
        public string BackupName => LanguageManager.GetInstance().Translate("Backup Name");
        public string TargetDirectory => LanguageManager.GetInstance().Translate("Target Directory");
        public string SourceDirectory => LanguageManager.GetInstance().Translate("Source Directory");
        public string BackupType => LanguageManager.GetInstance().Translate("Backup Type");
        public string Validate => LanguageManager.GetInstance().Translate("Validate");

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
            LanguageManager.LanguageChanged += OnLanguageChanged;
        }

        private void OnLanguageChanged(object sender, EventArgs e)
        {
            OnPropertyChanged(nameof(BackupName));
            OnPropertyChanged(nameof(TargetDirectory));
            OnPropertyChanged(nameof(SourceDirectory));
            OnPropertyChanged(nameof(BackupType));
            OnPropertyChanged(nameof(Validate));
        }

        public void AddWork(string name, string target, string source, string type)
        {
            SaveWorkModel saveWorkModel = new SaveWorkModel(name, target, source, type);
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
    }


}
