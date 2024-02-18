using EasySaveProject.AddFolder;
using EasySaveProject.ExecuteFolder;
using EasySaveProject.LanguageFolder;
using System.Windows;
using System.Windows.Input;
using System.ComponentModel;

using static EasySaveProject.MenuFolder.MenuRouteur;
using System;

namespace EasySaveProject.MenuFolder
{
    public class MenuViewModel : INotifyPropertyChanged
    {
        public ICommand AddWorkCommand { get; private set; }
        public ICommand ExecuteWorkCommand { get; private set; }
        public ICommand SettingsCommand { get; private set; }

        public string AddWorkButton => LanguageManager.GetInstance().Translate("Add work");
        public string ExecuteWorkButton => LanguageManager.GetInstance().Translate("Execute work");
        public string SettingsButton => LanguageManager.GetInstance().Translate("Settings");
        public event PropertyChangedEventHandler PropertyChanged;


        public enum Menu
        {
            AddWork = 0,
            ExecuteWork = 1,
            ProgressView = 2,
            Settings = 3,
        }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void redirect(int input)
        {
            // Convert the integer input to a Menu enum value
            Menu menuOption = (Menu)input;
            // Get the singleton instance of MenuRouter
            MenuRouter menuRouter = MenuRouter.Instance;

            // Use the instance to call methods on it
            menuRouter.redirect(menuOption);
        }

        public MenuViewModel() 
        {
            //Initialize command
            AddWorkCommand = new RelayCommand(param => NavigateToAddWork(), param => CanNavigate()) ;
            ExecuteWorkCommand = new RelayCommand(param => NavigateToExecuteWork(), param => CanNavigate());
            SettingsCommand = new RelayCommand(param => NavigateToSettings(), param => CanNavigate());
            LanguageManager.LanguageChanged += OnLanguageChanged;
        }

        private void OnLanguageChanged(object sender, EventArgs e)
        {
            OnPropertyChanged(nameof(AddWorkButton));
            OnPropertyChanged(nameof(ExecuteWorkButton));
            OnPropertyChanged(nameof(SettingsButton));
        }

        //this will determine if the command can be executed
        private bool CanNavigate()
        {
            return true;
        }


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
