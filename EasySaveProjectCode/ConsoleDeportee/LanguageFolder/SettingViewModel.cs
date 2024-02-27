using System.ComponentModel;
using System.Windows.Input;
using System.Windows;
using ConsoleDeportee.AddWork;
using ConsoleDeportee.ExecuteFolder;

namespace ConsoleDeportee.LanguageFolder
{
    public class SettingViewModel : INotifyPropertyChanged
    {
       
        public event PropertyChangedEventHandler? PropertyChanged;
        public ICommand SwitchToFrenchCommand { get; private set; }
        public ICommand SwitchToEnglishCommand { get; private set; }

        public ICommand AddWorkCommand { get; private set; }
        public ICommand ExecuteWorkCommand { get; private set; }
        public ICommand SettingsCommand { get; private set; }
        public SettingViewModel()
        {
            //Initialize command
            AddWorkCommand = new RelayCommand(param => NavigateToAddWork(), param => CanNavigate());
            ExecuteWorkCommand = new RelayCommand(param => NavigateToExecuteWork(), param => CanNavigate());
            SettingsCommand = new RelayCommand(param => NavigateToSettings(), param => CanNavigate());
        }


        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
